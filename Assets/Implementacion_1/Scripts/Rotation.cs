using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector2 turn;
    
    void Update()
    {
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
        if ((transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0) && turn.x < 0)
        {
            //rotatingClockwise = true;
            transform.Rotate(0, 0, -1);
        }
        else if (transform.eulerAngles.z > 0 && turn.x > 0)
        {
            transform.Rotate(0, 0, 1);
            //rotatingClockwise = false;
        }
    }
}
