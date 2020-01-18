using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject skeet;
    // Start is called before the first frame update
    public void yeetSkeet(float firespeed)
    {
            GameObject Skeet2Yeet = Instantiate(skeet, this.transform.position, this.transform.rotation);
            Skeet2Yeet.GetComponent<Rigidbody>().velocity = Skeet2Yeet.transform.forward * firespeed;
    }
}
