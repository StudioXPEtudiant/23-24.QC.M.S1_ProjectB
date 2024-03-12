using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Collectable")
            return;

        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().Stunt();
        }
        
        Destroy(gameObject);
    }
}
