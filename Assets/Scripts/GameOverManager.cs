using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Button restartButton;
    public Button mainMenuButton;

    public string mainGameSceneName;
    public string mainMenuSceneName;
    
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        scoreText.text = "Score: " + score;
        
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void Restart()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnEnable()
    {
        score = PlayerPrefs.GetInt("score");
    }
}
