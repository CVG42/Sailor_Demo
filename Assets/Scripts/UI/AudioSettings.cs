using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] AudioMixer mixer;
    [SerializeField] private bool sfxisOn = true;
    public Image sfxOn;
    public Image sfxOff;

    [SerializeField] private bool bgmIsOn = true;
    public Image bgmOn;
    public Image bgmOff;

    private const float muteVolume = -80f;
    private const float fullVolume = 0f;

    private void Start()
    {
        // Load saved settings at the start
        LoadAudioSettings();
        UpdateButtonStates();
    }

    public void ToggleSFX()
    {
        // Toggle SFX volume between mute and full volume
        sfxisOn = !sfxisOn;
        float newVolume = sfxisOn ? fullVolume : muteVolume;
        mixer.SetFloat("sfxVol", newVolume);

        // Save to PlayerPrefs
        PlayerPrefs.SetFloat("sfxVol", newVolume);
        PlayerPrefs.Save();

        // Update button images
        UpdateButtonStates();
    }

    public void ToggleBGM()
    {
        // Toggle BGM volume between mute and full volume
        bgmIsOn = !bgmIsOn;
        float newVolume = bgmIsOn ? fullVolume : muteVolume;
        mixer.SetFloat("musicVol", newVolume);

        // Save to PlayerPrefs
        PlayerPrefs.SetFloat("musicVol", newVolume);
        PlayerPrefs.Save();

        // Update button images
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        // Update SFX button visuals based on current setting
        sfxisOn = PlayerPrefs.GetFloat("sfxVol", fullVolume) != muteVolume;
        sfxOn.gameObject.SetActive(sfxisOn);
        sfxOff.gameObject.SetActive(!sfxisOn);

        // Update BGM button visuals based on current setting
        bgmIsOn = PlayerPrefs.GetFloat("musicVol", fullVolume) != muteVolume;
        bgmOn.gameObject.SetActive(bgmIsOn);
        bgmOff.gameObject.SetActive(!bgmIsOn);
    }

    private void LoadAudioSettings()
    {
        // Load and apply saved settings
        float sfxVol = PlayerPrefs.GetFloat("sfxVol", fullVolume);
        float musicVol = PlayerPrefs.GetFloat("musicVol", fullVolume);

        mixer.SetFloat("sfxVol", sfxVol);
        mixer.SetFloat("musicVol", musicVol);
    }
}
