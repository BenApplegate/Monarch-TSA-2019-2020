using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAim : MonoBehaviour
{

    InputActions input; //Input object from the new Input System
    Vector2 inputPos; //The vector given by the Mouse/Controller joystick
    Quaternion StartRotation; // The starting rotation of the object

    public int verticalMin; // The vertical minimum of the Camera
    public int verticalMax; // The vertical maximum of the Camera
    public int horizontalMin; // The horizontal Minimum of the Camera
    public int horizontalMax; // The horizontal Maximum of the Camera

    private float horizontal;//the current horizontal shift of the camera 
    private float vertical; //the currnet vertical shift of the camera

    

    private void Awake()
    {
        input = new InputActions(); // create the inputActions class
        input.Archery.Aim.performed += ctx => inputPos = ctx.ReadValue<Vector2>(); //Stores position of Mouse / Controller joystick to inputPos
        input.Archery.Aim.canceled += ctx => inputPos = Vector2.zero; // Resets inputPos to zero when no longer moviong joystick / mouse
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // hides mouse curser
        Cursor.lockState = CursorLockMode.Locked; // Locks curser to center of screen
        StartRotation = this.transform.rotation; // Sets Start Rotation

        transform.rotation = StartRotation; // Sets Camera to starting rotation

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inputPos);
        if(vertical >= verticalMin && inputPos.y < 0) // tests if camera is told to move down, and if it is allowed to move down
        {
            vertical += inputPos.y * .1f; //changes vertical to match the camera's shift in rotation
            transform.Rotate(-inputPos.y * .1f, 0, 0, Space.Self); // Rotates Camera
        }
        if (vertical <= verticalMax && inputPos.y > 0)// tests if camera is told to move up and if it is allowed to move up
        {
            vertical += inputPos.y * .1f;// changes vertical to match the camera's shift in rotation
            transform.Rotate(-inputPos.y * .1f, 0, 0, Space.Self);// Rotates Camera
        }


        if (horizontal <= horizontalMax && inputPos.x > 0) // Tests if camera is being told to go right, and if it is allowed to
        {
            //Debug.Log("Right");
            horizontal += inputPos.x * .1f; //Adjusts horizontal to reflect shift in rotation
            transform.Rotate(0, inputPos.x * .1f, 0, Space.World); //Rotates Camera
        }
        if (horizontal >= horizontalMin && inputPos.x < 0)// Tests if camera is being told to go left, and if it is allowed to
        {
            //Debug.Log("Left");
            horizontal += inputPos.x * .1f; // Adjusts horizontal to reflect shift in camera's rotation
            transform.Rotate(0, inputPos.x * .1f, 0, Space.World); // Rotates Camera
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
