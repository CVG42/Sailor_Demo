using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationX : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (!isOnPlay) return;
        float currentAngle = transform.eulerAngles.x;
        newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle.x, 200f * Time.deltaTime);
        begin = Mathf.MoveTowardsAngle(currentAngle, startAngle.x, 200f * Time.deltaTime);
        turn.x = Input.GetAxis("Mouse X");
    }

    private void OnMouseDrag()
    {
        if (!isOnPlay) return;

        if (!Flip)
        {
            if (turn.x < 0)
            {
                transform.rotation = Quaternion.Euler(begin, startAngle.y, startAngle.z);
            }
            else if (turn.x > 0)
            {
                transform.rotation = Quaternion.Euler(newAngle, targetAngle.y, targetAngle.z);
            }
        }
        else
        {
            if (turn.x > 0)
            {
                transform.rotation = Quaternion.Euler(begin, startAngle.y, startAngle.z);
            }
            else if (turn.x < 0)
            {
                transform.rotation = Quaternion.Euler(newAngle, targetAngle.y, targetAngle.z);
            }
        }
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
