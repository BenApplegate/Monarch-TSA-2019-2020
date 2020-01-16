using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    float startingFOV;
    public Camera cam;
    public float zoomFactor = 2;

    private void Awake()
    {
            input = new InputActions();
            input.Archery.FireArrow.performed += ctx => inputStrength = ctx.ReadValue<float>();
            input.Archery.FireArrow.performed += ctx => fireing = true;
            input.Archery.FireArrow.canceled += ctx => fireing = false;
            input.Archery.FireArrow.canceled += ctx => Fire();
        
    }

    private void BuildStrength()
    {
        if(strength < maxStrength)
        {
            strength += inputStrength * strengthBuildRate * Time.deltaTime;
        }
        if (zoom)
        {
            cam.fieldOfView = startingFOV - (strength*zoomFactor);
        }
    }

    private void Fire()
    {


        cam.fieldOfView = startingFOV;
        if (arrowsShot < arrows) { 
        GameObject fired = Instantiate(Arrow, this.transform.position, this.transform.rotation);
        fired.transform.Rotate(90, 0, 0);
        fired.GetComponent<Rigidbody>().velocity += this.transform.forward * strength * power;
        fired.GetComponent<Arrow>().shootProjectile = this;
        strength = 0;
        arrowsShot++;
        if(arrowsShot == arrows)
            {
                endGame();
            }
    }
    }
    // Start is called before the first frame update
    void Start()
    {
        startingFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireing && arrowsShot<arrows)
        {
            BuildStrength();
        }
    }

    private void endGame()
    {
        Debug.Log("Game Over");
        //put code that ends the game here
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
