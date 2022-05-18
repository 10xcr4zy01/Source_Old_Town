using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingScript : MonoBehaviour
{
    [SerializeField] AudioMixer mainAudioMixer;

    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle fullScreenToggle;

    [SerializeField] GameObject menuSetting, menuHowToPlay, menuExit;

    Resolution[] resolutions;
    float currentVolume;

    void Start()
    {
        //Update fullscreen
        fullScreenToggle.isOn = PlayerPrefs.GetInt("isFullScreen") == 1 ? true : false;


        //Update resolution value for dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.value = PlayerPrefs.GetInt("currentResolitionIndex");
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu(menuSetting);
            CloseMenu(menuHowToPlay);
            CloseMenu(menuExit);
        }

        UpdateAudioMixerValue();


    }

    private void UpdateAudioMixerValue ()
    {
        mainAudioMixer.GetFloat("volume", out currentVolume);
        PlayerPrefs.SetFloat("volume", currentVolume);
        volumeSlider.value = currentVolume;
    }


    //For UI changes
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("currentResolitionIndex", resolutionIndex);
    } 

    public void FullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        int fullScreenValue = isFullScreen ? 1 : 0;
        PlayerPrefs.SetInt("isFullScreen", fullScreenValue);
    }

    public void SetVolume(float volume)
    {
        mainAudioMixer.SetFloat("volume", volume);
    }

    public void CloseMenu (GameObject menuObject)
    {
        menuObject.SetActive(false);
    }
    
}

