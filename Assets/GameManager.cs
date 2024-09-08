using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Action<GAME_STATE> onGameStateChanged;
    
    [Header("Game State and player")]
    public GAME_STATE currentGameState;
    public PlayerController player;

    [Space(10)]
    [Header("Path Conditions")]
    [Space(5)]
    public List<RotationPathCondition> rotatingPathConditions = new List<RotationPathCondition>();
    public List<VerticalMovablePathCondition> verticalMovablePathConditions = new List<VerticalMovablePathCondition>();
    public List<HorizontalMovablePathCondition> horizontalMovablePathConditions = new List<HorizontalMovablePathCondition>();
    public List<ActivatedPathCondition> activatedPathConditions = new List<ActivatedPathCondition>();

    [Space(5)]
    [Header("Activable Platforms")]
    public GameObject[] activablePlatforms;

    void Update()
    {
        ConditionPath();
        if (player.walking) return;
    }

    public void ChangeGameState(GAME_STATE _newGameState)
    {
        if (currentGameState == _newGameState) return;

        currentGameState = _newGameState;
        Debug.Log("Game state changed to: " + currentGameState);

        if (onGameStateChanged != null)
        {
            onGameStateChanged.Invoke(currentGameState);
        }
    }

    public void ConditionPath()
    {
        foreach(RotationPathCondition pc in rotatingPathConditions)
        {
            int count = 0;
            
            for(int i = 0; i < pc.conditions.Count; i++)
            {
                if(pc.conditions[i].conditionObject.eulerAngles == pc.conditions[i].eulerAngle)
                {
                    count++;
                    pc.conditions[i].conditionObject.GetComponent<Collider>().enabled = false;
                }
            }
            
            foreach(SinglePath sp in pc.paths)
                sp.block.possiblePaths[sp.index].active = (count == pc.conditions.Count);
        }

        foreach(VerticalMovablePathCondition vm in verticalMovablePathConditions)
        {
            int count = 0;

            for (int i = 0; i < vm.conditions.Count; i++)
            {
                if (Vector3.Distance(vm.conditions[i].conditionPlatform.position, vm.conditions[i].XYposition) < 0.01f)
                {
                    count++;
                    vm.conditions[i].conditionPlatform.GetComponent<Collider>().enabled = false; //can be commented depending on the platform collider
                }
            }

            foreach(SinglePath sp in vm.paths)
                sp.block.possiblePaths[sp.index].active = (count == vm.conditions.Count);
        }

        foreach(HorizontalMovablePathCondition hm in horizontalMovablePathConditions)
        {
            int count = 0;

            for(int i = 0; i < hm.conditions.Count; i++)
            {
                if (Vector3.Distance(hm.conditions[i].conditionPlatform.position, hm.conditions[i].XYposition) < 0.01f)
                {
                    count++;
                    hm.conditions[i].conditionPlatform.GetComponent<Collider>().enabled = false; //can be commented depending on the platform collider
                }
            }

            foreach(SinglePath sp in hm.paths)
                sp.block.possiblePaths[sp.index].active = (count == hm.conditions.Count);
        }

        foreach (ActivatedPathCondition ap in activatedPathConditions)
        {
            int count = 0;

            for (int i = 0; i < ap.conditions.Count; i++)
            {
                if (Vector3.Distance(ap.conditions[i].conditionPlatform.position, ap.conditions[i].XYposition) < 0.01f)
                {
                    count++;
                }
            }

            foreach (SinglePath sp in ap.paths)
                sp.block.possiblePaths[sp.index].active = (count == ap.conditions.Count);
        }
    }
}

public enum GAME_STATE
{
    PLAY,
    PAUSE,
    GAME_OVER
}

[System.Serializable]
public class RotationPathCondition
{
    public string name;
    public List<RotationCondition> conditions;
    public List<SinglePath> paths;
}

[System.Serializable]
public class VerticalMovablePathCondition
{
    public string name;
    public List<MoveCondition> conditions;
    public List<SinglePath> paths;
}

[System.Serializable]
public class HorizontalMovablePathCondition
{
    public string name;
    public List<MoveCondition> conditions;
    public List<SinglePath> paths;
}

[System.Serializable]
public class ActivatedPathCondition
{
    public string name;
    public List<MoveCondition> conditions;
    public List<SinglePath> paths;
}

[System.Serializable]
public class RotationCondition
{
    public Transform conditionObject;
    public Vector3 eulerAngle;
}

[System.Serializable]
public class MoveCondition
{
    public Transform conditionPlatform;
    public Vector3 XYposition;
}

[System.Serializable]
public class SinglePath
{
    public Walkable block;
    public int index;
}
