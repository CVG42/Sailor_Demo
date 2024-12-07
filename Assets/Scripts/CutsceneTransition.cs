using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CutsceneTransition : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] AudioMixer mixer;

    private void Awake()
    {
        mixer.SetFloat("musicVol", -80);
        mixer.SetFloat("sfxVol", -80);
    }

    void Start()
    {
        StartCoroutine(EndTransition());
    }

    IEnumerator EndTransition()
    {
        yield return new WaitForSeconds(35.5f);
        transition.SetTrigger("End");
        yield return new WaitForSeconds(4f);
        mixer.SetFloat("musicVol", 0);
        mixer.SetFloat("sfxVol", 0);
        SceneManager.LoadScene("Menu");
    }
}
