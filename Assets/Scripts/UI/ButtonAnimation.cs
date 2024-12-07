using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    Button btn;
    Vector3 upScale = new Vector3(.8f, .8f, .8f);
    [Header("Original Button Scale")]
    [Tooltip("Set the original scale of the buttons for the after-anim scale")]
    [SerializeField] Vector3 originalScale;

    private void Awake()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Anim);
    }

    void Anim()
    {
        LeanTween.scale(gameObject, upScale, 0.1f);
        LeanTween.scale(gameObject, originalScale, 0.1f).setDelay(0.1f);
    }
}
