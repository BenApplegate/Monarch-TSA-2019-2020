﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    InputActions input; // Create new input object
    float inputStrength; // Holds the current value of the fire button
    public float strength; //stores the current fire strength 
    public int maxStrength; //stores the maximum strength that can be acheved
    public float strengthBuildRate; //the rate that stength increases
    public float power = 3; // the multiplyer that changes the speed of the arrow
    bool fireing = false; // shows if the player is holding the fire button
    public bool arrowLimit = true; // decides if the arrowLimit should be enforced
    public int arrows = 5; // how many arrows the player gets
    private float arrowsShot = 0; // how many arrows the player has fired

    public GameObject Arrow; // the object that is used as the arrow

    public bool zoom = true; // shows if the camera zooms when 
    float startingFOV; // The FOV that the camera starts with
    public Camera cam; // the camera
    public float zoomFactor = 2; // the factor that the camera zooms by
    public Camera endCam;
    public GameObject target;

    public BetterPauseMenu BetterPauseMenu;
    ArcheryScoreManager scoreManager;

    bool ending = false;
    float endingTimer = 0;
    public Text ArrowsLeft;
    Quaternion CamRot;

    public BowAnimationManager bow;

    private void Awake()
    {
            input = new InputActions();
            input.Archery.FireArrow.performed += ctx => inputStrength = ctx.ReadValue<float>(); // stores the current value of the fire button
            input.Archery.FireArrow.performed += ctx => fireing = true; // stores that the player is fireing
            input.Archery.FireArrow.canceled += ctx => fireing = false; // stores that the player is no longer fireing
            input.Archery.FireArrow.canceled += ctx => Fire(); // fires the arrow when the button is released
        
    }

    private void BuildStrength()
    {
        if(strength < maxStrength) // if current strenghth is less then the max strength
        {
            strength += inputStrength * strengthBuildRate * Time.deltaTime; // builds strength
        }
        if (zoom) // if camera is supposed to zoom
        {
            cam.fieldOfView = startingFOV - (strength*zoomFactor); // zooms camera based on strength
        }
    }

    private void Fire()
    {


        cam.fieldOfView = startingFOV; // resets camera FOV
        if (arrowsShot < arrows) { //if you have arrows left to fire
        GameObject fired = Instantiate(Arrow, this.transform.position + (this.transform.forward / 2), this.transform.rotation); //creates an arrow and saves it into the reference fired
        fired.transform.Rotate(90, 0, 0); // Rotates the arrow so it faces the right way
        fired.GetComponent<Rigidbody>().velocity += this.transform.forward * strength * power; // gives the arrow speed
        fired.GetComponent<Arrow>().shootProjectile = this; // Gives the arrow a reference to this script
        strength = 0; // resets strength
        arrowsShot++; // increments arrowsShot
            cam.transform.rotation = CamRot;
            cam.GetComponent<CameraAim>().vertical = 0;
            cam.GetComponent<CameraAim>().horizontal = 0;
            if (arrowsShot == arrows) // If the player has fired all of their arrows
            {
                Debug.Log("endGame");
                ending = true;

            }
    }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ArcheryScoreManager>();
        startingFOV = cam.fieldOfView; // sets starting FOV
        CamRot = cam.transform.rotation;
        BetterPauseMenu = FindObjectOfType<BetterPauseMenu>();
        BetterPauseMenu.Resume();
    }

    // Update is called once per frame
    void Update()
    {
        bow.UpdateStrength(strength, maxStrength);

        if (fireing && arrowsShot<arrows) // If you have arrows to fire and you are holding the fire button
        {
            BuildStrength();
        }

        if (BetterPauseMenu.gameIsPaused)
        {
            input.Disable();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            input.Enable();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        ArrowsLeft.text = "Arrows Left: " + (arrows - arrowsShot).ToString();
        if (ending)
        {
            if (endingTimer >= 1)
            {
                ending = false;
                endGame();
            }
            else{
                endingTimer += Time.deltaTime;
                Debug.Log(endingTimer);
            }
        }

    }

    private void endGame()
    {
        Debug.Log("Game Over");
        endCam.gameObject.GetComponent<Transform>().position = new Vector3(endCam.gameObject.transform.position.x, endCam.gameObject.transform.position.y, target.transform.position.z - 1.5f);
        endCam.enabled = true;
        cam.enabled = false;
        scoreManager.EndGame();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
