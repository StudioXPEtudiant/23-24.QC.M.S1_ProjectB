using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource[] audioSources;
    
    void Start()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = PlayerPrefs.GetFloat("mainGameVolume");
        }
    }
}
