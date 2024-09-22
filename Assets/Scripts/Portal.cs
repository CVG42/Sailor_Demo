using UnityEngine;

public class Portal : MonoBehaviour
{
    public Color portalColor;
    public GameObject targetPortal;
    public GameObject player1;
    public GameObject target;

    private void Start()
    {
        //portalColor = Color.red;
        target.GetComponent<Renderer>().material.color = portalColor;
        GetComponent<Renderer>().material.color = portalColor;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor playerColor = other.GetComponent<PlayerColor>();

            if (playerColor != null && playerColor.currentColor == portalColor)
            {
                TeleportPlayer();
            }
            
        }
    }

    private void TeleportPlayer()
    {
        if (targetPortal != null)
        {
            player1.SetActive(false);
            targetPortal.SetActive(true);
        }
        
    }
}
