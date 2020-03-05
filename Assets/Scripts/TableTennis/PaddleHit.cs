using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PaddleHit : MonoBehaviour
{

    public Rigidbody rb;
    public float horizontal_hit = 5f;
    public float vertical_hit = 2f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ball")
        {
            rb.AddForce(horizontal_hit, vertical_hit, 0, ForceMode.Impulse);
        }
    }

}
