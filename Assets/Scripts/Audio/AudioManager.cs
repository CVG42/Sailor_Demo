using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private Scene scene;
    public static AudioManager instance;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource blockSource;

    [Header("Clips to play")]
    [SerializeField] AudioClip levelOne;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip menu;
    [SerializeField] AudioClip blocks;
    [SerializeField] AudioClip colorChange;
    [SerializeField] AudioClip teleport;
    [SerializeField] AudioClip completed;
    [SerializeField] AudioClip button;
    [SerializeField] AudioClip rotate;
    [SerializeField] AudioClip correct;

    private AudioClip currentMusicClip;

    [Header("Audio Settings")]
    [SerializeField] AudioMixer mixer;
    float currentVol = 0;
    float currenMusicVol = 0;
    [SerializeField] private bool sfxisOn;

    [SerializeField] private bool bgmIsOn;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Teleport()
    {
        sfxSource.PlayOneShot(teleport);
    }

    public void Rotate()
    {
        sfxSource.PlayOneShot(rotate);
    }

    public void Button()
    {
        sfxSource.PlayOneShot(button);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("sfxVol"))
        {
            currentVol = PlayerPrefs.GetFloat("sfxVol", currentVol);
            mixer.SetFloat("sfxVol", currentVol);
        }

        if (PlayerPrefs.HasKey("musicVol"))
        {
            currenMusicVol = PlayerPrefs.GetFloat("musicVol", currenMusicVol);
            mixer.SetFloat("musicVol", currenMusicVol);
        }

        scene = SceneManager.GetActiveScene();
        PlayBackgroundMusic(scene.name);

        blockSource.clip = blocks;
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    // Play background music based on scene name
    private void PlayBackgroundMusic(string sceneName)
    {
        AudioClip newClip = sceneName == "Menu" ? menu : levelOne;

        // Only switch music if it's different from the currently playing clip
        if (newClip != currentMusicClip)
        {
            currentMusicClip = newClip;
            musicSource.clip = newClip;
            musicSource.Play();
        }
    }

    // Event handler for when the scene changes
    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        PlayBackgroundMusic(newScene.name);
    }

    public void LinedUp()
    {
        sfxSource.PlayOneShot(correct);
    }

    public void ChangeColor()
    {
        sfxSource.PlayOneShot(colorChange);
    }

    public void WalkSound()
    {
        sfxSource.PlayOneShot(walk);
    }

    public void PlayBlocks()
    {
        blockSource.Play();
    }

    public void StopBlocks()
    {
        blockSource.Stop();
    }

    public void LevelComplete()
    {
        sfxSource.PlayOneShot(completed);
    }

    public void VolumeOff()
    {
        currentVol = -80;
        mixer.SetFloat("sfxVol", currentVol);
        PlayerPrefs.SetFloat("sfxVol", currentVol);
    }

    public void VolumeOn()
    {
        currentVol = 0;
        mixer.SetFloat("sfxVol", currentVol);
        PlayerPrefs.SetFloat("sfxVol", currentVol);
    }

    public void SoundOff()
    {
        currenMusicVol = -80;
        mixer.SetFloat("musicVol", currenMusicVol);
        PlayerPrefs.SetFloat("musicVol", currenMusicVol);
    }

    public void SoundOn()
    {
        currenMusicVol = 0;
        mixer.SetFloat("musicVol", currenMusicVol);
        PlayerPrefs.SetFloat("musicVol", currenMusicVol);
    }
}
