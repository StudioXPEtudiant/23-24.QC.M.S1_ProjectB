using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshStatic : MonoBehaviour
{
    public void Awake()
    {
        if (!GetComponent<NavMeshModifier>())
            gameObject.AddComponent<NavMeshModifier>();

        gameObject.layer = 6;
    }
}
