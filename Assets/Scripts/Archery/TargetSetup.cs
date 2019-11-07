using UnityEngine;

public class TargetSetup : MonoBehaviour
{
    public Transform player; // Allows reference to player position
    public float minDist; // Sets minimum distance from the player
    public float maxDist; // Sets maximum distance from the player
    public float range; // Holds the RNG for the placement of the target
    public Vector3 placement; // Used for placing target at random distance between minimum and maximum distance

    // Start is called before the first frame update
    // Initializes target distance from player
    void Start()
    {
        range = Random.Range(minDist, maxDist);
        placement.z += range;
        transform.position = player.position + placement;
    }

    
    void fixedUpdate()
    {
        
    }
}
