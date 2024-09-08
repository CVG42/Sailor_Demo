using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMuvement : MonoBehaviour
{
    public Vector3 laserMuvement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(laserMuvement * 20 * Time.deltaTime);
    }
}
