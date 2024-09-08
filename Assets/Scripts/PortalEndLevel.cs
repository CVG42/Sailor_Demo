using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEndLevel : MonoBehaviour
{
    public Color portalColor;
    private void Start()
    {
        portalColor = Color.blue;
        GetComponent<Renderer>().material.color = portalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor playerColor = other.GetComponent<PlayerColor>();

            if (playerColor != null && playerColor.currentColor == portalColor)
            {
                SceneManager.LoadScene("Level 2");
                Debug.Log("Se cambio la escena");
            }

        }
    }
}
