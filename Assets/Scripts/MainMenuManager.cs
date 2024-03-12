using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject creditsMenu;

    public Slider lookSensitivitySlider;
    public Slider mainGameVolumeSlider;

    public string mainGameSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if (!PlayerPrefs.HasKey("lookSensitivity"))
        {
            PlayerPrefs.SetFloat("lookSensitivity", lookSensitivitySlider.value);
        }
        else
        {
            lookSensitivitySlider.value = PlayerPrefs.GetFloat("lookSensitivity");
        }

        if (!PlayerPrefs.HasKey("mainGameVolume"))
        {
            PlayerPrefs.SetFloat("mainGameVolume", mainGameVolumeSlider.value / 100);
        }
        else
        {
            mainGameVolumeSlider.value = PlayerPrefs.GetFloat("mainGameVolume") * 100;
        }
        
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
        
        lookSensitivitySlider.onValueChanged.AddListener(LookSensitivityChanged);
        mainGameVolumeSlider.onValueChanged.AddListener(MainGameVolumeChanged);
    }

    public void Play()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void OptionsBack()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
    
    public void CreditsBack()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void LookSensitivityChanged(float newSensitivity)
    {
        PlayerPrefs.SetFloat("lookSensitivity", lookSensitivitySlider.value);
    }
    
    public void MainGameVolumeChanged(float newVolume)
    {
        PlayerPrefs.SetFloat("mainGameVolume", mainGameVolumeSlider.value / 100);
    }
}
