using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    
    public int numsc;

    // got most of this from a youtube tortrial video

    float ctime = 0f;
    float stime = 30f;
    public Text ct;

    public coxswain cox;

    // Start is called before the first frame update
    void Start()
    {
        ctime = stime;
    }

    // Update is called once per frame
    void Update()
    {
        ctime -= 1 * Time.deltaTime;

        if (ctime <= 10)
        {
            ct.color = Color.yellow;
            if (ctime <= 5)
            {
                ct.color = Color.red;
            }
        }
        if (ctime <= 0)
        {
            ctime = 0;
        }
        ct.text = "Time: " + ctime.ToString("0");
        if (ctime == 0)
        {
            ct.text = "Game Over";
        }
    }


}
