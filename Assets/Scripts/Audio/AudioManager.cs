using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        musicSource.clip = levelOne;
        musicSource.Play();
        blockSource.clip = blocks;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(scene.name == "Menu")
        {
            musicSource.clip = menu;
            musicSource.Play();
        }
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
        musicSource.volume = 0f;
        PlayerPrefs.SetFloat("musicSource", musicSource.volume);
    }

    public void VolumeOn()
    {
        musicSource.volume = 1f;
        PlayerPrefs.SetFloat("musicSource", musicSource.volume);
    }

    public void SoundOff()
    {
        sfxSource.volume = 0f;
        PlayerPrefs.SetFloat("sfxSource", sfxSource.volume);
    }

    public void SoundOn()
    {
        sfxSource.volume = 1f;
        PlayerPrefs.SetFloat("sfxSource", sfxSource.volume);
    }
}
