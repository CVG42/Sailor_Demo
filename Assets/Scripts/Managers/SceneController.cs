using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;
    public TutorialManager tutorialController;
    public bool hasTutorial = false;

    void Start()
    {
        if (tutorialController != null)
        {
            hasTutorial = true; // Cambia según el nivel
        }
        else
        {
            hasTutorial = false;
        }
    }

    public void NextLevel()
    {
        if (hasTutorial)
        {
            if (tutorialController != null && tutorialController.tutorialStep == 4)
            {
                tutorialController.CompleteStep();
                StartCoroutine(LoadLevel());
                Debug.Log("Se cambió la escena después de completar el tutorial.");
            }
            else
            {
                Debug.Log("No puedes avanzar hasta que el tutorial esté completo.");
            }
        }
        else
        {
            StartCoroutine(LoadLevel());
            Debug.Log("Se cambió la escena (sin tutorial).");
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }

        transitionAnim.SetTrigger("Start");
        yield return null;
    }
}
