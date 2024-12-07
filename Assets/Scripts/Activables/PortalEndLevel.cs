using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEndLevel : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color portalColor;

    //[SerializeField] GameObject victory;
    public string nextSceneName;
    public int levelIndex;

    [SerializeField] SceneController sceneAnim;

    private void Start()
    {
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

            if (playerColor != null && playerColor.innerColor == portalColor)
            {
                //SceneManager.LoadScene("Level 2");
                //victory.SetActive(true);
                PlayerPrefs.SetInt("Lv" + levelIndex, 1);
                sceneAnim.NextLevel();
                //SceneManager.LoadScene(nextSceneName);
                Debug.Log("Se cambio la escena");
            }

        }
    }
}
