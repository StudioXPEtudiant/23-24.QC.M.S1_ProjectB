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
    
    public Button playButton;
    public Button optionButton;
    public Button optionBackButton;

    public Slider sensitivitySlider;

    public string mainGameSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if (PlayerPrefs.GetFloat("mouseSensitivity") == 0)
        {
            PlayerPrefs.SetFloat("mouseSensitivity", sensitivitySlider.value);
        }
        else
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("mouseSensitivity");
        }
        
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
        
        playButton.onClick.AddListener(Play);
        optionButton.onClick.AddListener(Options);
        optionBackButton.onClick.AddListener(OptionsBack);
        
        sensitivitySlider.onValueChanged.AddListener(SensitivityChanged);
    }

    private void Play()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }

    private void Options()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    private void OptionsBack()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

    private void SensitivityChanged(float newSensitivity)
    {
        PlayerPrefs.SetFloat("mouseSensitivity", sensitivitySlider.value);
    }
}
