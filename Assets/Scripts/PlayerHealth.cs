using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public Slider healthBar;

    private void Start()
    {
        healthBar.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        
        if (health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGameManager>())
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGameManager>().GameOver();
            }
        }
    }
}
