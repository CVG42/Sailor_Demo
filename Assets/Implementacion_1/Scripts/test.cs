using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [SerializeField] bool isMoving = false;
    float turn;
    [Header("Movimiento")]
    public float LimitNegative;
    public float LimitPositive;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            turn = touch.deltaPosition.x;
            if (Physics.Raycast(ray, out hit))
            {               
                if (hit.transform == transform || isMoving)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            isMoving = true;
                            break;
                        case TouchPhase.Moved:
                            Movement();
                            break;
                        case TouchPhase.Ended:
                            isMoving = false;
                            if (transform.position.z > (LimitPositive - 0.09f)){
                                transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.Round(transform.position.z));
                            }
                            break;
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }

    void Movement()
    {
        if (turn < 0 && transform.position.z < LimitPositive)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y, LimitPositive), 25 * Time.deltaTime);
           
        }
        else if (turn > 0  && transform.position.z > LimitNegative)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, LimitNegative), 25 * Time.deltaTime);
        }
    }
}