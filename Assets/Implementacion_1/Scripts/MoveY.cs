using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveY : MonoBehaviour
{
    public Vector2 turn;
    public float final, start;
    //-4.87

    // Update is called once per frame
    void Update()
    {
        turn.y = Input.GetAxis("Mouse Y");
    }

    private void OnMouseDrag()
    {
        if (transform.position.y < start && turn.y > 0)
        {
            transform.Translate(0,1 * Time.deltaTime * 4, 0);
        }
        else if (transform.position.y > final && turn.y < 0)
        {
            transform.Translate(0, -1 * Time.deltaTime * 4, 0);
        }
    }
}
