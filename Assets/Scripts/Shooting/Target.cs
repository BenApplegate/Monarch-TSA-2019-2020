
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Rigidbody rb;
    public int points = 0;
    private int totalpoints;
    void Start()
    {
        StartCoroutine(Seconds());
        rb.AddForce(0 - Random.Range(5, 9), Random.Range(10, 12), 0, ForceMode.Impulse);
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        totalpoints = points + 5;
    }
    WaitForSecondsRealtime Seconds()
    {
        return new WaitForSecondsRealtime(5);
    }
}
