using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    bool isOnPlay;

    public Vector2 turn;
    public float final, start;

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

        if (transform.position.x < start && turn.x > 0)
        {
            transform.Translate(0, 1 * Time.deltaTime * 4, 0);
        }
        else if (transform.position.x > final && turn.x < 0)
        {
            transform.Translate(0, -1 * Time.deltaTime * 4, 0);
        }
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
