using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ShootProjectile shootProjectile; // This is broken

    public Arrow(ShootProjectile shootProjectile) // This is broken
    {
        this.shootProjectile = shootProjectile;
    }

    private void OnCollisionEnter(Collision collision) // The if else statements are broken
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

        if (collision.gameObject.tag == "Bullseye")
        {
            shootProjectile.points += 50;
            Debug.Log(shootProjectile.points);
        }
        else if (collision.gameObject.tag == "Inner Circle")
        {
            shootProjectile.points += 25;
            Debug.Log(shootProjectile.points);
        }
        else if (collision.gameObject.tag == "Outer Circle")
        {
            shootProjectile.points += 10;
            Debug.Log(shootProjectile.points);
        }
        else if (collision.gameObject.tag == "Target")
        {
            shootProjectile.points += 5;
            Debug.Log(shootProjectile.points);
        }
        else
        {
            shootProjectile.points += 0;
            Debug.Log(shootProjectile.points);
        }
    }
}