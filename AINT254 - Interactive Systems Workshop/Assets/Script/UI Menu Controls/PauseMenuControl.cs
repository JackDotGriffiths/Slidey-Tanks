using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour {

    private bool Paused;
    public static bool LockControls;

    public GameObject PausedUI;
    public GameObject CurrentUI;

    public Text LevelName;
    
    

    // Use this for initialization
    void Start () {
        Paused = false;
        LockControls = false;
        LevelName.text = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            PauseRigidbodies();
            LockControls = true;
            Paused = true;
            PausedUI.SetActive(true);
            CurrentUI.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused == true)
        {
            LockControls = false;
            Paused = false;
            PausedUI.SetActive(false);
            CurrentUI.SetActive(true);
        }
	}

    private void PauseRigidbodies()
    {
        //Find all game objects in the scene, and if they have a RigidBody, freeze it.
        GameObject[] obj = FindObjectsOfType<GameObject>();
        for(int i = 0; i < obj.Length; i++)
        {
            if (obj[i].GetComponent<Rigidbody>() == true)
            {
                obj[i].GetComponent<Rigidbody>().Sleep();
            }
        }
        
    }
    private void PlayRigidbodies()
    {
        //Find all game objects in the scene, and then unfreeze it.
        GameObject[] obj = FindObjectsOfType<GameObject>();
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].GetComponent<Rigidbody>() == true)
            {
                obj[i].GetComponent<Rigidbody>().WakeUp();
            }
        }
    }
}
