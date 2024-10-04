using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYTouch : MonoBehaviour
{
    public bool isMoving = false;
    float turn;
    [Header("Movimiento")]
    public float LimitNegative;
    public float LimitPositive;
    private void Update()
    {
        if (isMoving)
        {
            if(Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                turn = touch.deltaPosition.y;
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        Movement();
                        break;
                    case TouchPhase.Ended:
                       
                        if (transform.position.y > (LimitPositive - 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                        }
                        else if (transform.position.y < (LimitNegative + 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
                        }
                        isMoving = false;
                        break;
                }
            }
        }
    }

    void Movement()
    {
        if (turn > 0 && transform.position.y < LimitPositive)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, LimitPositive, transform.position.z), 14 * Time.deltaTime);

        }
        else if (turn < 0 && transform.position.y > LimitNegative)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, LimitNegative, transform.position.z), 14 * Time.deltaTime);
        }
    }
}
