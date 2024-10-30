using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Color currentColor; 
    private Renderer playerRenderer;

    private void Start()
    {
       
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.material.color = currentColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rayo"))
        {
            AudioManager.instance.ChangeColor();
            if (TutorialManager.GetInstance().tutorialStep == 3)
            {
                TutorialManager.GetInstance().CompleteStep();
            }
            Color rayColor = other.gameObject.GetComponent<Renderer>().material.color;
            ChangeColor(rayColor);
        }
    }

    public void ChangeColor(Color newColor)
    {
        currentColor = newColor;
        playerRenderer.material.color = newColor;
    }
}