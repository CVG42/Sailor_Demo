using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZTouch : MonoBehaviour
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
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                turn = touch.deltaPosition.x;
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        Movement();
                        break;
                    case TouchPhase.Ended:

                        if (transform.position.z > (LimitPositive - 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
                        }
                        else if (transform.position.z < (LimitNegative + 0.09f))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
                        }
                        isMoving = false;
                        break;
                }
            }
        }
    }

    void Movement()
    {
        if (turn < 0 && transform.position.z < LimitPositive)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, LimitPositive), 14 * Time.deltaTime);

        }
        else if (turn > 0 && transform.position.z > LimitNegative)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, LimitNegative), 14 * Time.deltaTime);
        }
    }
}
