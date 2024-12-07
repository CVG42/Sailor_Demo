using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableButton : MonoBehaviour
{
    bool isOnPlay;
    public bool isActivated;

    private Vector3 initialPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] GameObject platform;
    [SerializeField] private Vector3 platformPos;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
        isActivated = false;
        initialPos = transform.position;
    }

    void Update()
    {
        if (!isOnPlay) return;
        if (isActivated)
        {
            
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, new Vector3(platformPos.x, platformPos.y, platformPos.z), .6f * Time.deltaTime);
        }
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActivated)
        {
            AudioManager.instance.Button();
            AudioManager.instance.Rotate();
            transform.position = endPos;
            isActivated = true;
            Debug.Log("Button is activated");
        }
    }
}
