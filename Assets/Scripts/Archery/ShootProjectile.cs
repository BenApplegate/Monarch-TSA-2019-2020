using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootProjectile : MonoBehaviour
{
    InputActions input;
    float inputStrength;
    
    public int points;

    public float strength;
    public int maxStrength;
    public float strengthBuildRate;
    public float power = 3;
    bool fireing = false;
    public bool arrowLimit = true;
    public int arrows = 5;
    private float arrowsShot = 0;

    public GameObject Arrow;

    public bool zoom = true;
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
