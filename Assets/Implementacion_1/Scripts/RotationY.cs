using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    public Vector2 turn;
    [SerializeField] Vector3 targetAngle;
    [SerializeField] bool Flip;
    bool isOnPlay;
    Vector3 startAngle;
    float newAngle, begin;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);

    }

    void Update()
    {
        if (!isOnPlay) return;

        float currentAngle = transform.eulerAngles.y;
        newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle.y, 200f * Time.deltaTime);
        begin = Mathf.MoveTowardsAngle(currentAngle, startAngle.y, 200f * Time.deltaTime);
        turn.x = Input.GetAxis("Mouse X");
    }

    private void OnMouseDrag()
    {
        if (!isOnPlay) return;

        if (!Flip)
        {
            if (turn.x < 0)
            {
                transform.rotation = Quaternion.Euler(startAngle.x, begin, startAngle.z);
            }
            else if (turn.x > 0)
            {
                transform.rotation = Quaternion.Euler(targetAngle.x, newAngle, targetAngle.z);
            }
        }
        else
        {
            if (turn.x > 0)
            {
                transform.rotation = Quaternion.Euler(startAngle.x, begin, startAngle.z);
            }
            else if (turn.x < 0)
            {
                transform.rotation = Quaternion.Euler(targetAngle.x, newAngle, targetAngle.z);
            }
        }

    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
