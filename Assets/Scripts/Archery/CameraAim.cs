﻿using System.Collections;
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

    public float horizontal;//the current horizontal shift of the camera 
    public float vertical; //the currnet vertical shift of the camera

    public bool shakeCamera = true; // Should the camera shake?
    public float shakefactor = .01f; // How many degrees does the camera shake
    public float shakeSlowFactor = 5; // how slow should the camera shake
    int shakeCount = 0;
    float Hshake;
    float Vshake;



    private void Awake()
    {
        input = new InputActions(); // create the inputActions class
        input.Archery.Aim.performed += ctx => inputPos = ctx.ReadValue<Vector2>(); //Stores position of Mouse / Controller joystick to inputPos
        input.Archery.Aim.canceled += ctx => inputPos = Vector2.zero; // Resets inputPos to zero when no longer moviong joystick / mouse
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false; // hides mouse curser
        Cursor.lockState = CursorLockMode.Locked; // Locks curser to center of screen
        StartRotation = this.transform.rotation; // Sets Start Rotation

        transform.rotation = StartRotation; // Sets Camera to starting rotation

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inputPos);
        if (vertical >= verticalMin && inputPos.y < 0) // tests if camera is told to move down, and if it is allowed to move down
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

        if (shakeCamera) ShakeCamera(); // tests if the camera should shake

        if(BetterPauseMenu.gameIsPaused) { // Pause the game and open the Pause Menu
            
            Cursor.visible = true;
            input.Disable();
            Cursor.lockState = CursorLockMode.None;
        }
        if (!(BetterPauseMenu.gameIsPaused)) { // Unpauses the game and closes the pause menu
            Cursor.visible = false;
            input.Enable();
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void ShakeCamera()
    {
        ShootProjectile projectile = this.GetComponent<ShootProjectile>(); // gets the ShootProjectile object on the camera

        if (shakeCount == 0 || shakeCount == 5) {
         Hshake = Random.Range(-shakefactor * projectile.strength / shakeSlowFactor, shakefactor * projectile.strength / shakeSlowFactor); // Randomly picks horizontal shake
         Vshake = Random.Range(-shakefactor * projectile.strength / shakeSlowFactor, shakefactor * projectile.strength / shakeSlowFactor); // Randomly picks Vertical shake
    }
        else{
            vertical -= Vshake/10;
            transform.Rotate(Vshake/10, 0, 0, Space.Self);
            horizontal += Hshake/10;
            transform.Rotate(0, Hshake/10, 0, Space.World);
        }

        if(shakeCount == 0 || shakeCount < 9)
        {
            shakeCount++;
        }
        else
        {
            shakeCount = 0;
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
