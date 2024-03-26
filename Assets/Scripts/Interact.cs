using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject[] eventGameobjects;
    public UnityEvent[] events;

    public TMP_Text interactionText;
    
    public float detectionRadius;

    public void Update()
    {
        for (int i = 0; i < eventGameobjects.Length; i++)
        {
            if (Vector3.Distance(transform.position, eventGameobjects[i].transform.position) <= detectionRadius)
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }

    public void OnInteract()
    {
        for (int i = 0; i < eventGameobjects.Length; i++)
        {
            if (Vector3.Distance(transform.position, eventGameobjects[i].transform.position) <= detectionRadius)
            {
                events[i].Invoke();
            }
        }
    }
}
