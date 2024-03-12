using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementRyan : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float mouseSensitivity = 100f;

    public Transform camera;
    
    float xRotation = 0f;

    private bool mouseLocked = true;
    
    Vector3 velocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        
        /*if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            velocity.y = 0f;
        }*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveInput = GetComponent<PlayerInput>().actions.FindAction("Move").ReadValue<Vector2>();

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        controller.Move(move * speed * deltaTime);

        /*if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        */

        /*if (Input.GetKeyDown(KeyCode.Escape) && mouseLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseLocked = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !mouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseLocked = true;
        }*/

        //float mouseX = Input.GetAxis("Mouse X") * PlayerPrefs.GetFloat("mouseSensitivity") * 100 * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("mouseSensitivity") * 100 * Time.deltaTime;

        Vector2 lookInput = GetComponent<PlayerInput>().actions.FindAction("Look").ReadValue<Vector2>();
        
        float lookX = lookInput.x * PlayerPrefs.GetFloat("lookSensitivity") * 10 * deltaTime;
        float lookY = lookInput.y * PlayerPrefs.GetFloat("lookSensitivity") * 10 * deltaTime;
            
        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * lookX);
    }
}