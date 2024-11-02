using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYTouch : MonoBehaviour
{
    public bool isMoving = false;
    public bool GoalPositive;
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

                        Snap();
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
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, LimitPositive, transform.position.z), 4 * Time.deltaTime);

        }
        else if (turn < 0 && transform.position.y > LimitNegative)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, LimitNegative, transform.position.z), 4 * Time.deltaTime);
        }
    }

    void Snap()
    {
        if (GoalPositive)
        {
            if (transform.position.y > (LimitPositive - 0.7f))
            {
                transform.position = new Vector3(transform.position.x, LimitPositive, transform.position.z);
                Collider collider = GetComponent<Collider>();
                collider.enabled = false;

            }
            else if (transform.position.y < (LimitNegative + 0.7f))
            {
                transform.position = new Vector3(transform.position.x, LimitNegative, transform.position.z);
            }
        }
        else if (!GoalPositive)
        {
            if (transform.position.y > (LimitPositive - 0.7f))
            {
                transform.position = new Vector3(transform.position.x, LimitPositive, transform.position.z);

            }
            else if (transform.position.y < (LimitNegative + 0.7f))
            {
                transform.position = new Vector3(transform.position.x, LimitNegative, transform.position.z);
                Collider collider = GetComponent<Collider>();
                collider.enabled = false;
            }
        }
    }
}
