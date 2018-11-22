using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuControl : MonoBehaviour {

    private bool Paused;
    public Button buttonRestart;

    public static bool LockControls;
    

    // Use this for initialization
    void Start () {
        Paused = false;
        LockControls = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            LockControls = true;
            Paused = true;
            buttonRestart.GetComponent<Button>().enabled = true;
            buttonRestart.GetComponent<Image>().enabled = true;
            buttonRestart.GetComponentInChildren<Text>().enabled = true;
            PauseRigidbodies();

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused == true)
        {
            LockControls = false;
            Paused = false;
            buttonRestart.GetComponent<Button>().enabled = false;
            buttonRestart.GetComponent<Image>().enabled = false;
            buttonRestart.GetComponentInChildren<Text>().enabled = false; ;
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
