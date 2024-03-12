using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject[] collectablePrefab;

    private void Start()
    {
        GameObject collectableModel = Instantiate(collectablePrefab[UnityEngine.Random.Range(0, collectablePrefab.Length)], transform.position, transform.rotation, transform);
    }
}
