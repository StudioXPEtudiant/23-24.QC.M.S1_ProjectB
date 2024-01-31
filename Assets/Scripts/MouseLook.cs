using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100;

    public Transform playerBody;
    
    float xRotation = 0f;

    private bool mouseLocked = true;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mouseLocked)
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
        }
        
        float mouseX = Input.GetAxis("Mouse X") * PlayerPrefs.GetFloat("mouseSensitivity") * 10 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("mouseSensitivity") * 10 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
        print(PlayerPrefs.GetFloat("mouseSensitivity"));
    }
}
