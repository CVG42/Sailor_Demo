using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationXTouch : MonoBehaviour
{
    public bool isRotating = false;
    float turn;
    Vector3 startAngle;
    float newAngle, begin;
    [Header("Rotacion")]
    [SerializeField] bool FlipControls;
    [SerializeField] Vector3 targetAngle;

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
                float currentAngle = transform.eulerAngles.x;
                newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle.x, 200f * Time.deltaTime);
                begin = Mathf.MoveTowardsAngle(currentAngle, startAngle.x, 200f * Time.deltaTime);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        Rotation();
                        break;
                    case TouchPhase.Ended:

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
                transform.rotation = Quaternion.Euler(begin, startAngle.y, startAngle.z);
            }
            else if (turn > 0)
            {
                transform.rotation = Quaternion.Euler(newAngle, targetAngle.y, targetAngle.z);
            }
        }
        else
        {
            if (turn > 0)
            {

                transform.rotation = Quaternion.Euler(begin, startAngle.y, startAngle.z);
            }
            else if (turn < 0)
            {
                transform.rotation = Quaternion.Euler(newAngle, targetAngle.y, targetAngle.z);
            }
        }
    }
}
