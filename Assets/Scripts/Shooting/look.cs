using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class look : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    InputActions input;

    void Awake()
    {
        input = new InputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // hides mouse curser
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        if(BetterPauseMenu.gameIsPaused) {
            
            Cursor.visible = true;
            input.Disable();
            Cursor.lockState = CursorLockMode.None;
        }
        if (!(BetterPauseMenu.gameIsPaused)) {
            Cursor.visible = false;
            input.Enable();
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
