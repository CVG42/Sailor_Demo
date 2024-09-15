using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationZ : MonoBehaviour
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
        
        /*if(rotatingClockwise && (transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0))
        {
            transform.Rotate(0,0,-1);
        }
        else if(!rotatingClockwise && transform.eulerAngles.z > 0){
            transform.Rotate(0,0,1);
        }*/

    }

    private void OnMouseDrag()
    {
        if (!isOnPlay) return;

        if (Flip)
        {
            if ((transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0) && turn.x < 0)
            {
                transform.Rotate(0, 0, -1);
            }
            else if (transform.eulerAngles.z > 0 && turn.x > 0)
            {
                transform.Rotate(0, 0, 1);
            }
        }
        else
        {
            if ((transform.eulerAngles.z < 270 || transform.eulerAngles.z <= 180) && turn.x < 0)
            {
                transform.Rotate(0, 0, 1);
            }
            else if (transform.eulerAngles.z > 180 && turn.x > 0)
            {
                transform.Rotate(0, 0, -1);
            }
        }
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}