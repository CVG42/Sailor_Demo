using UnityEngine;

public class Portal : MonoBehaviour
{
    public Color portalColor;
    public Transform targetPortal; 
    private void Start()
    {
        portalColor = Color.red;
        GetComponent<Renderer>().material.color = portalColor;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor playerColor = other.GetComponent<PlayerColor>();

            if (playerColor != null && playerColor.currentColor == portalColor)
            {
                
                TeleportPlayer(other.transform);
            }
            
        }
    }

    private void TeleportPlayer(Transform player)
    {
        if (targetPortal != null)
        {
            player.position = targetPortal.position;
            player.rotation = targetPortal.rotation; 
        }
        
    }
}
