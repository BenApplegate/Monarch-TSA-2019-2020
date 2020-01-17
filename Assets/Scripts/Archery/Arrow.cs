using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ShootProjectile shootProjectile; // This is broken
    public CapsuleCollider otherColider;
    bool hasHit = false;

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    public Arrow(ShootProjectile shootProjectile) // This is broken
    {
        this.shootProjectile = shootProjectile;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!hasHit)
        {
            hasHit = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            otherColider.enabled = false;
            Debug.Log(collision.name);
        }
    }
}