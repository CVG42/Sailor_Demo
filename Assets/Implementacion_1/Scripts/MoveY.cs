using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveY : MonoBehaviour
{
    bool isOnPlay;

    public Vector2 turn;
    public float final, start;
    //-4.87

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
    }

    void Update()
    {
        if (!isOnPlay) return;
        turn.y = Input.GetAxis("Mouse Y");
    }

    private void OnMouseDrag()
    {
        if (!isOnPlay) return;

        if (transform.position.y < start && turn.y > 0)
        {
            transform.Translate(0,1 * Time.deltaTime * 4, 0);
        }
        else if (transform.position.y > final && turn.y < 0)
        {
            transform.Translate(0, -1 * Time.deltaTime * 4, 0);
        }
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
