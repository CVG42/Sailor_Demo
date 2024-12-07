using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    bool isOnPlay;

    [SerializeField] private Animator platformAnim;
    public ActivableButton button;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);

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
        if (other.CompareTag("Player") && button.isActivated == true)
        {
            Debug.Log("Button is activated");
            // buttonAnim.SetBool("activated", true);
            platformAnim.SetBool("activated", true);
            //rayAnim.SetBool("activated", true);
        }
    }
}
