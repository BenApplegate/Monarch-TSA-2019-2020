using UnityEngine;
using UnityEngine.SceneManagement;
public class Shotgun : MonoBehaviour
{
    public string Archery;
    // Start is called before the first frame update
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public float shots = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
                Shoot();
            shots++;
        }

        else if (shots >= 5)
        {
            SceneManager.LoadScene(Archery);
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            
        }
    }
}
