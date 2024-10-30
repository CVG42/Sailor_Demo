using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationYTouch : MonoBehaviour
{
    public bool isRotating = false;
    float turn;
    Vector3 startAngle;
    float newAngle, begin;
    [Header("Rotacion")]
    [SerializeField] Vector3 targetAngle;
    [SerializeField] bool FlipControls;

    bool isOnPlay;

    private void Start()
    {
        startAngle = transform.localRotation.eulerAngles;
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

        if (isRotating)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                turn = touch.deltaPosition.x;
                float currentAngle = transform.eulerAngles.y;
                newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle.y, 200f * Time.deltaTime);
                begin = Mathf.MoveTowardsAngle(currentAngle, startAngle.y, 200f * Time.deltaTime);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        AudioManager.instance.PlayBlocks();
                        Rotation();
                        break;
                    case TouchPhase.Ended:
                        AudioManager.instance.StopBlocks();
                        isRotating = false;
                        break;
                }
            }
        }
    }
    void Rotation()
    {
        if (!isOnPlay) return;

        if (!FlipControls)
        {
            if (turn < 0)
            {
                transform.rotation = Quaternion.Euler(startAngle.x, begin, startAngle.z);
            }
            else if (turn > 0)
            {
                transform.rotation = Quaternion.Euler(targetAngle.x, newAngle, targetAngle.z);
            }
        }
        else
        {
            if (turn > 0)
            {

                transform.rotation = Quaternion.Euler(startAngle.x, begin, startAngle.z);
            }
            else if (turn < 0)
            {
                transform.rotation = Quaternion.Euler(targetAngle.x, newAngle, targetAngle.z);
            }
        }
    }
}
