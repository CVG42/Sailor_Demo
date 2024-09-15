using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    public Vector2 turn;
    [SerializeField] bool Flip;

    bool isOnPlay;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
    }

    void Update()
    {
        if (!isOnPlay) return;

        turn.x = Input.GetAxis("Mouse X");

    }

    private void OnMouseDrag()
    {
        if (!isOnPlay) return;

        if (Flip)
        {
            if ((transform.eulerAngles.y > 270 || transform.eulerAngles.y <= 0) && turn.x < 0)
            {
                transform.Rotate(0, -1, 0);
            }
            else if (transform.eulerAngles.y > 0 && turn.x > 0)
            {
                transform.Rotate(0, 1, 0);
            }
        }
        else{
            if ((transform.eulerAngles.y < 270 || transform.eulerAngles.y <= 180) && turn.x < 0)
            {
                transform.Rotate(0, 1, 0);
            }
            else if (transform.eulerAngles.y > 180 && turn.x > 0)
            {
                transform.Rotate(0, -1, 0);
            }
        }

    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
