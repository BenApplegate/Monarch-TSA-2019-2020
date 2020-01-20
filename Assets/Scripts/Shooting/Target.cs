
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Rigidbody rb;
    public int points = 0;

    public GameObject fractured;
    void Start()
    {

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            Die();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("HIT! " + Time.time);
        GameObject broken = Instantiate(fractured, this.transform.position, Quaternion.identity);
        foreach(GameObject rb in broken.GetComponent<List>().objects)
        {
            Vector3 velocity = this.gameObject.GetComponent<Rigidbody>().velocity;
            rb.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(velocity.x - 3, velocity.x +3), Random.Range(velocity.y - 3, velocity.y+3),Random.Range(velocity.z -3, velocity.z +3));
            rb.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
        
        
        Destroy(gameObject);
    }
    
}
