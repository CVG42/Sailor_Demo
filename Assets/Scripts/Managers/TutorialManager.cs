using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public CanvasGroup touchPlatformText;
    public CanvasGroup movePlatformText;
    public CanvasGroup laserText;
    public CanvasGroup portalText;
    public CanvasGroup finalPortalText;

    public int tutorialStep = 0;
    private bool[] stepsCompleted;

    public float fadeDuration = 1.0f;
    private SceneController sceneController;

    static TutorialManager instance;

    public static TutorialManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        stepsCompleted = new bool[5];
        tutorialStep = 0;
        //sceneController.hasTutorial = true;
        ShowTouchPlatformTutorial();
    }


    public void CompleteStep()
    {
        if (tutorialStep < stepsCompleted.Length)
        {
            stepsCompleted[tutorialStep] = true;
            tutorialStep++;


            switch (tutorialStep)
            {
                case 1:
                    ShowMovePlatformTutorial();
                    break;
                case 2:
                    ShowPortalTutorial();
                    break;
                case 3:
                    ShowLaserTutorial();
                    break;
                case 4:
                    ShowFinalPortalTutorial();
                    break;
                case 5:
                    EndTutorial();
                    break;
            }
        }
    }


    public bool IsStepComplete(int step)
    {
        if (step >= 0 && step < stepsCompleted.Length)
        {
            return stepsCompleted[step];
        }
        return false;
    }


    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float time = 0;
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1;
    }



    private IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float time = 0;
        canvasGroup.alpha = 1;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(false);
    }


    public void ShowTouchPlatformTutorial()
    {
        //sceneController.hasTutorial = true;
        if (!IsStepComplete(0))
        {
            StartCoroutine(FadeIn(touchPlatformText));
            StartCoroutine(FadeOut(movePlatformText));
            StartCoroutine(FadeOut(laserText));
            StartCoroutine(FadeOut(finalPortalText));
        }
    }





    public void ShowLaserTutorial()
    {
        if (!IsStepComplete(3))
        {
            StartCoroutine(FadeOut(touchPlatformText));
            StartCoroutine(FadeIn(laserText));
            StartCoroutine(FadeOut(movePlatformText));
            StartCoroutine(FadeOut(portalText));
            StartCoroutine(FadeOut(finalPortalText));
        }
    }


    public void ShowPortalTutorial()
    {
        if (!IsStepComplete(2))
        {
            StartCoroutine(FadeOut(touchPlatformText));
            StartCoroutine(FadeOut(movePlatformText));
            StartCoroutine(FadeOut(laserText));
            StartCoroutine(FadeIn(portalText));
            StartCoroutine(FadeOut(finalPortalText));
        }
    }


    public void ShowMovePlatformTutorial()
    {
        if (!IsStepComplete(3))
        {
            StartCoroutine(FadeOut(touchPlatformText));
            StartCoroutine(FadeIn(movePlatformText));
            StartCoroutine(FadeOut(laserText));
            StartCoroutine(FadeOut(portalText));
            StartCoroutine(FadeOut(finalPortalText));
        }
    }


    public void ShowFinalPortalTutorial()
    {
        if (!IsStepComplete(4))
        {
            StartCoroutine(FadeOut(touchPlatformText));
            StartCoroutine(FadeOut(movePlatformText));
            StartCoroutine(FadeOut(laserText));
            StartCoroutine(FadeOut(portalText));
            StartCoroutine(FadeIn(finalPortalText));
        }
    }

    public void EndTutorial()
    {
        if (!IsStepComplete(5))
        {
            StartCoroutine(FadeOut(touchPlatformText));
            StartCoroutine(FadeOut(movePlatformText));
            StartCoroutine(FadeOut(laserText));
            StartCoroutine(FadeOut(portalText));
            StartCoroutine(FadeOut(finalPortalText));
        }
    }
}
