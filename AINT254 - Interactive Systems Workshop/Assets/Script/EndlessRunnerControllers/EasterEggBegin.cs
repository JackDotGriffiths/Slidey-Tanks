using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasterEggBegin : MonoBehaviour {
    private int TimesPressed = 0;
	// Update is called once per frame
 	public void ButtonPress() {
        TimesPressed += 1;

        if(TimesPressed == 10)
        {
            SceneManager.LoadScene(12);
        }
	}
}
