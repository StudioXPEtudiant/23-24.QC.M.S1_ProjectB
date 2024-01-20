using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public string gameOverSceneName;

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}