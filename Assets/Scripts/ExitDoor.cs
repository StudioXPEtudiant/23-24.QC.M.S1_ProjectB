using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public GameObject gameManager;
    
    public void Exit()
    {
        gameManager.GetComponent<MainGameManager>().GameOver();
    }
}
