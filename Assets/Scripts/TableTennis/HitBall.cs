using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{ 
    public Rigidbody rb;
    public float horizontal_hit = 5f;
    public float vertical_hit = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(horizontal_hit, vertical_hit, 0, ForceMode.Impulse);
            Debug.Log("Click Registered");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            Debug.Log("Ball Collided with Object!");
        }
    }
}
