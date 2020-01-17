using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ShootProjectile shootProjectile; // This is broken
    public CapsuleCollider otherColider;
    public ArcheryScoreManager ScoreManager;
    bool hasHit = false;

    private void Start()
    {
        ScoreManager = FindObjectOfType<ArcheryScoreManager>();
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
            this.gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            hasHit = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            otherColider.enabled = false;
            ScoreManager.AddScore(collision);
        }
    }
}