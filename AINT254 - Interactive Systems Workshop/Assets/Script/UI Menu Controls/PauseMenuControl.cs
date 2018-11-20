using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuControl : MonoBehaviour {

    private bool Paused;
    public Button buttonRestart;
    

    // Use this for initialization
    void Start () {
        Paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            Time.timeScale = 0;
            Paused = true;
            buttonRestart.GetComponent<Button>().enabled = true;
            buttonRestart.GetComponent<Image>().enabled = true;
            buttonRestart.GetComponentInChildren<Text>().enabled = true; ;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused == true)
        {
            Time.timeScale = 1;
            Paused = false;
            buttonRestart.GetComponent<Button>().enabled = false;
            buttonRestart.GetComponent<Image>().enabled = false;
            buttonRestart.GetComponentInChildren<Text>().enabled = false; ;
        }
	}
}
