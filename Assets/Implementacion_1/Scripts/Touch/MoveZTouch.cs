using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZTouch : MonoBehaviour
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
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                turn = touch.deltaPosition.x;
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        AudioManager.instance.PlayBlocks();
                        Movement();
                        break;
                    case TouchPhase.Ended:
                        AudioManager.instance.StopBlocks();
                        if (transform.position.z > (LimitPositive - 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
                        }
                        else if (transform.position.z < (LimitNegative + 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
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

        if (turn < 0 && transform.position.z < LimitPositive)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, LimitPositive), 14 * Time.deltaTime);

        }
        else if (turn > 0 && transform.position.z > LimitNegative)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, LimitNegative), 14 * Time.deltaTime);
        }
    }
}
