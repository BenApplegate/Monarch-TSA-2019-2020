using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MainMenuLoader : MonoBehaviour
{
    SceneManager SceneManager = new SceneManager();

    public Transform[] locations;
    private Vector3[] positions;
    private Quaternion[] rotations;
    int loadIndex;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        
    }

    private void Start()
    {
        loadIndex = 0;
        positions = new Vector3[locations.Length];
        rotations = new Quaternion[locations.Length];
        for(int i = 0; i < locations.Length; i++)
        {
            positions[i] = locations[i].position;
            rotations[i] = locations[i].rotation;
        }
        
    }

    public void LoadMenu(int locationIndex)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("BetterMenu");
        loadIndex = locationIndex;
    }

    private void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Method Called");
        if(scene.name == "BetterMenu")
        {
            Debug.Log("BetterMenu Called");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().SetPositionAndRotation(positions[loadIndex], rotations[loadIndex]);
            Debug.Log(positions[loadIndex]);
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Time.timeScale = 1;
        }
    }
}
