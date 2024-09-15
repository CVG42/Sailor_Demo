using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    bool isOnPlay;
    [SerializeField] bool RightToLeft;
    public Vector2 turn;
    public float start, final;

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

        if (RightToLeft)
        {
        if (transform.position.z > start && turn.x > 0)
        {
            transform.Translate(0, 0, -8 * Time.deltaTime);
        }
        else if (transform.position.z < final && turn.x < 0)
        {
            transform.Translate(0, 0, 8 * Time.deltaTime);
        }
        }else{
            if (transform.position.z < start && turn.x < 0)
            {
                transform.Translate(0, 0, 8 * Time.deltaTime);
            }
            else if (transform.position.z > final && turn.x > 0)
            {
                transform.Translate(0, 0, -8 * Time.deltaTime);
            }
        }

    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
