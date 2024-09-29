using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYTouch : MonoBehaviour
{
    bool isOnPlay;
    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;
   
    public bool detectSwipeAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    [Header("Movimiento")]
    public float LimitNegative;
    public float LimitPositive;
    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnPlay) return;
        foreach (Touch touch in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        fingerUpPos = touch.position;
                        fingerDownPos = touch.position;
                    }

                    //Detects Swipe while finger is still moving on screen
                    if (touch.phase == TouchPhase.Moved)
                    {
                        if (!detectSwipeAfterRelease)
                        {
                            fingerDownPos = touch.position;
                            DetectSwipe();
                        }
                    }

                    //Detects swipe after finger is released from screen
                    if (touch.phase == TouchPhase.Ended)
                    {
                        fingerDownPos = touch.position;
                        DetectSwipe();
                    }
                }
            }

        }
    }

    void DetectSwipe()
    {
        if (!isOnPlay) return;
        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            Debug.Log("Vertical Swipe Detected!");
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;

        }
        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            Debug.Log("Horizontal Swipe Detected!");
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
        else
        {
            Debug.Log("No Swipe Detected!");
        }
    }

    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    void OnSwipeUp()
    {
        if(transform.position.y < LimitPositive )
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, LimitPositive, transform.position.z), 14 * Time.deltaTime);
        }
        
    }

    void OnSwipeDown()
    {
        if (transform.position.y > LimitNegative)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,LimitNegative,transform.position.z), 14 * Time.deltaTime);
        }
    }

    void OnSwipeLeft()
    {

    }

    void OnSwipeRight()
    {

    }
    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
