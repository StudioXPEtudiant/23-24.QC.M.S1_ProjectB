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

    public string mainGameSceneName;
    
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        scoreText.text = "Score: " + score;
        
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }

    private void OnEnable()
    {
        score = PlayerPrefs.GetInt("score");
    }
}
