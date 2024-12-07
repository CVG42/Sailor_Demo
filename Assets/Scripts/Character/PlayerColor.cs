using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    //public Color currentColor;
    private Material orb;
    //private Renderer playerRenderer;

    [ColorUsage(true, true)]
    public Color innerColor;

    [ColorUsage(true, true)]
    public Color startColor;

    private void Start()
    {
        orb = GetComponent<Renderer>().sharedMaterial;
        orb.SetColor("_Fresnel_Color", startColor);
        //playerRenderer = GetComponent<Renderer>();
        //playerRenderer.material.color = currentColor;
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
            //Color rayColor = other.gameObject.GetComponent<Renderer>().material.color;
            //ChangeColor(rayColor);
            orb.SetColor("_Fresnel_Color", innerColor);
        }
    }

    public void ChangeColor(Color newColor)
    {
        
        //currentColor = newColor;
        //playerRenderer.material.color = newColor;
    }
}
