using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    MoveXTouch moveX;
    MoveYTouch moveY;
    MoveZTouch moveZ;
    RotationYTouch rotationY;
    RotationZTouch rotationZ;
    RotationXTouch rotationX;
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) { 
                if (hit.transform.tag == "Interactable")
                {

                    if (hit.collider.gameObject.TryGetComponent<MoveYTouch>(out moveY))
                    {
                        moveY.isMoving = !moveY.isMoving;
                    }
                    else if (hit.collider.gameObject.TryGetComponent<MoveZTouch>(out moveZ))
                    {
                        moveZ.isMoving = !moveZ.isMoving;
                    }
                    else if (hit.collider.gameObject.TryGetComponent<MoveXTouch>(out moveX))
                    {
                        moveX.isMoving = !moveX.isMoving;
                    }
                    else if (hit.collider.gameObject.TryGetComponent<RotationYTouch>(out rotationY))
                    {
                        rotationY.isRotating = !rotationY.isRotating;
                    }
                    else if (hit.collider.gameObject.TryGetComponent<RotationXTouch>(out rotationX))
                    {
                        rotationX.isRotating = !rotationX.isRotating;
                    }
                    else if (hit.collider.gameObject.TryGetComponent<RotationZTouch>(out rotationZ))
                    {
                        rotationZ.isRotating = !rotationZ.isRotating;
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }
}
