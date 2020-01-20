using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Shotgun : MonoBehaviour
{

    public string Archery;
    // Start is called before the first frame update
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public float shots = 0f;
    public int MaxShots = 5;
    BetterPauseMenu BetterPauseMenu;
    ShootingScoreManger scoreManger;

    private void Start()
    {
        BetterPauseMenu = FindObjectOfType<BetterPauseMenu>();
        scoreManger = FindObjectOfType<ShootingScoreManger>();
        BetterPauseMenu.Resume();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !BetterPauseMenu.gameIsPaused)
        {
            if (shots < MaxShots)
            {
                Shoot();
                shots++;
            }


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
                scoreManger.addScore();
            }

        }
    }
}


