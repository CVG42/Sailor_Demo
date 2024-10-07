using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationZTouch : MonoBehaviour
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
                float currentAngle = transform.eulerAngles.z;
                newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle.z, 200f * Time.deltaTime);
                begin = Mathf.MoveTowardsAngle(currentAngle, startAngle.z, 200f * Time.deltaTime);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        if(TutorialManager.GetInstance().tutorialStep == 1)
                        {
                            TutorialManager.GetInstance().CompleteStep();
                        }
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
                transform.rotation = Quaternion.Euler(startAngle.x, startAngle.y, begin);
            }
            else if (turn > 0)
            {
                transform.rotation = Quaternion.Euler(targetAngle.x, targetAngle.y, newAngle);
            }
        }
        else
        {
            if (turn > 0)
            {

                transform.rotation = Quaternion.Euler(startAngle.x, startAngle.y, begin);
            }
            else if (turn < 0)
            {
                transform.rotation = Quaternion.Euler(targetAngle.x, targetAngle.y, newAngle);
            }
        }
    }
}
