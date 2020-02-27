using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public Camera cam;
    public float MovementSpeed;
    public float LookSpeed;
    public float slowFactor;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.magnitude < MovementSpeed)
            {
                rb.AddForce(transform.forward * Input.GetAxis("Vertical") * (MovementSpeed - rb.velocity.magnitude));
            }
        }
        else
        {
            rb.AddForce(-1 * rb.velocity * (rb.velocity.magnitude / slowFactor));
            
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.magnitude < MovementSpeed)
            {
                rb.AddForce(transform.right * Input.GetAxis("Horizontal") * (MovementSpeed - rb.velocity.magnitude));
            }
        }
        else
        {
            rb.AddForce(-1 * rb.velocity * (rb.velocity.magnitude / slowFactor));
            
        }

        if(Input.GetAxis("Mouse X") == 0)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            transform.Rotate(Vector3.up * LookSpeed * Input.GetAxis("Mouse X"));
        }
   
        cam.gameObject.transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * LookSpeed, Space.Self);



    }
}
