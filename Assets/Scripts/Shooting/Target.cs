
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    float x;
    float y;
    float z;
    Vector3 pos;
    void Start()
    {
        x = Random.Range(-5, 5);
        y = Random.Range(3, 7);
        z = 5;
        pos = new Vector3(x, y, z);
        transform.position = pos;
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
    }
}
