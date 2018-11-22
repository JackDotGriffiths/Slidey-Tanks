using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombPlace : MonoBehaviour {
    public static bool P1BombActive = false;

    public GameObject BombPrefab;
	// Update is called once per frame
	void Update () {
        if (PauseMenuControl.LockControls != true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && P1BombActive == false)
            {
                var Bomb = (GameObject)Instantiate(
                BombPrefab,
                this.transform.position,
                this.transform.rotation);
                P1BombActive = true;
            }
        }
	}
}
