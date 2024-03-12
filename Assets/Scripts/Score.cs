using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
    public int score;

    public TMP_Text scoreText;
    public TMP_Text interactionText;

    public float radius = 2.5f;
    
    public string gameplayActionMapName;

    private GameObject[] collectables;
    
    // Start is called before the first frame update
    void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");

        interactionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        interactionText.gameObject.SetActive(false);
        
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        
        scoreText.text = "Score : " + score;

        for (int i = 0; i < collectables.Length; i++)
        {
            if (Vector3.Distance(transform.position, collectables[i].transform.position) <= radius)
            {
                interactionText.gameObject.SetActive(true);
                
                if (GetComponent<PlayerInput>().actions.FindAction("Interact").triggered)
                {
                    score++;
                    Destroy(collectables[i]);
                }
            }
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
