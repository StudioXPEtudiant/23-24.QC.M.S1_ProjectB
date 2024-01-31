using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    public GameObject gameMenu;

    public Button resumeButton;
    public Button mainMenuButton;
    
    public string gameOverSceneName;
    public string mainMenuSceneName;
    
    private bool buttonClicked = false;
    private bool onMenu = false;
    
    private void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || buttonClicked) && onMenu)
        {
            gameMenu.SetActive(false);

            //Time.timeScale = 1;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            buttonClicked = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !onMenu)
        {
            gameMenu.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            onMenu = false;
            
            //Time.timeScale = 0;
            
            onMenu = true;
        }
    }

    private void Resume()
    {
        buttonClicked = true;
    }
    
    private void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}