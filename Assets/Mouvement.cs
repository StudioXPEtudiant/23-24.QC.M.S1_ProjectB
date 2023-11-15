using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float vitesseMouvement = 5.0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        
        Vector3 deplacement = transform.TransformDirection(new Vector3(deplacementHorizontal, 0, deplacementVertical));
        deplacement *= vitesseMouvement * Time.deltaTime;

        
        characterController.Move(deplacement);
    }
}