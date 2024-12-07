using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPortal : MonoBehaviour
{
    public GameObject targetPortal;
    public GameObject player1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Teleport();
            if(TutorialManager.GetInstance().tutorialStep == 2)
            {
                TutorialManager.GetInstance().CompleteStep();
            }
            TeleportPlayer();
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
