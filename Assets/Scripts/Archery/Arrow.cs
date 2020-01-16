using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ShootProjectile shootProjectile; // This is broken
    public CapsuleCollider otherColider;

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
        this.GetComponent<Rigidbody>().isKinematic = true;
        otherColider.enabled = false;
        Debug.Log(collision.name);
    }
}