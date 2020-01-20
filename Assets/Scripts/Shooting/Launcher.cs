using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject skeet;
    // Start is called before the first frame update
    public void yeetSkeet(float firespeed)
    {
            GameObject Skeet2Yeet = Instantiate(skeet, this.transform.position, Quaternion.identity);
            Skeet2Yeet.GetComponent<Rigidbody>().velocity = this.transform.forward * firespeed;
    }
}
