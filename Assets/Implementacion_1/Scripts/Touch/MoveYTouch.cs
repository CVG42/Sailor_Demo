using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYTouch : MonoBehaviour
{
    public bool isMoving = false;
    float turn;
    [Header("Movimiento")]
    public float LimitNegative;
    public float LimitPositive;

    bool isOnPlay;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }

    private void Update()
    {
        if (!isOnPlay) return;

        if (isMoving)
        {
            if(Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                turn = touch.deltaPosition.y;
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        /*if (TutorialManager.GetInstance().tutorialStep == 1)
                        {
                            TutorialManager.GetInstance().CompleteStep();
                        }*/
                        AudioManager.instance.PlayBlocks();
                        Movement();
                        break;
                    case TouchPhase.Ended:
                        AudioManager.instance.StopBlocks();
                        if (transform.position.y > (LimitPositive - 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                        }
                        else if (transform.position.y < (LimitNegative + 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                        }
                        isMoving = false;
                        break;
                }
            }
        }
    }

    void Movement()
    {
        if (!isOnPlay) return;

        if (turn > 0 && transform.position.y < LimitPositive)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, LimitPositive, transform.position.z), 14 * Time.deltaTime);

        }
        else if (turn < 0 && transform.position.y > LimitNegative)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, LimitNegative, transform.position.z), 14 * Time.deltaTime);
        }
    }
}
