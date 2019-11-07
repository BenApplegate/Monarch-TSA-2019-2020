using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAim : MonoBehaviour
{

    InputActions input; //Input object from the new Input System
    Vector2 inputPos;
    Quaternion StartRotation;

    public int verticalMin;
    public int verticalMax;
    public int horizontalMin;
    public int horizontalMax;

    
    private float horizontal;
    private float vertical;

    

    private void Awake()
    {
        input = new InputActions();
        input.Archery.Aim.performed += ctx => inputPos = ctx.ReadValue<Vector2>();
        input.Archery.Aim.canceled += ctx => inputPos = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartRotation = this.transform.rotation;

        transform.rotation = StartRotation;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputPos);
        if(vertical >= verticalMin && inputPos.y < 0)
        {
            vertical += inputPos.y * .1f;
            transform.Rotate(-inputPos.y * .1f, 0, 0, Space.World);
        }
        if (vertical <= verticalMax && inputPos.y > 0)
        {
            vertical += inputPos.y * .1f;
            transform.Rotate(-inputPos.y * .1f, 0, 0, Space.World);
        }


        if (horizontal <= horizontalMax && inputPos.x > 0)
        {
            Debug.Log("Right");
            horizontal += inputPos.x * .1f;
            transform.Rotate(0, inputPos.x * .1f, 0, Space.Self);
        }
        if (horizontal >= horizontalMin && inputPos.x < 0)
        {
            Debug.Log("Left");
            horizontal += inputPos.x * .1f;
            transform.Rotate(0, inputPos.x * .1f, 0, Space.Self);
        }
    }

    private void OnEnable()
    {
        input.Enable();  //Enables controlls
    }

    private void OnDisable()
    {
        input.Disable(); //Disables controlls if object gets disabled
    }
}
