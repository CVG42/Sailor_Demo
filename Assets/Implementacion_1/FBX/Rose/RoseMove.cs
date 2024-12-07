using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMove : MonoBehaviour
{
    public GameObject rose;
    public float speed;

    private Vector3 initialPos;

    private void Start()
    {
        initialPos = rose.transform.position;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, .2f * 2) - .2f;
        rose.transform.position = new Vector3(initialPos.x, initialPos.y + y, initialPos.z);
    }
}
