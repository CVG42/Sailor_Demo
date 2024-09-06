using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    public Vector2 turn;
    public float final, start;

    // Update is called once per frame
    void Update()
    {
        turn.x = Input.GetAxis("Mouse X");
    }

    private void OnMouseDrag()
    {
        if (transform.position.x < start && turn.x > 0)
        {
            transform.Translate(0, 1 * Time.deltaTime * 4, 0);
        }
        else if (transform.position.x > final && turn.x < 0)
        {
            transform.Translate(0, -1 * Time.deltaTime * 4, 0);
        }
    }
}
