using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableButton : MonoBehaviour
{
    bool isOnPlay;
    public bool isActivated;

    [SerializeField] private Animator buttonAnim, platformAnim = null;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
        isActivated = false;
    }

    void Update()
    {
        if (!isOnPlay) return;
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Debug.Log("Button is activated");
            buttonAnim.SetBool("activated", true);
            platformAnim.SetBool("activated", true);
        }
    }
}
