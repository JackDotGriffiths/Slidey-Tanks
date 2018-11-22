using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XboxBombPlace : MonoBehaviour
{
    public static bool P2BombActive = false;

    public GameObject BombPrefab;
    // Update is called once per frame
    void Update()
    {
        if (PauseMenuControl.LockControls != true)
        {
            if (Input.GetButton("Player2PlaceBomb") && P2BombActive == false)
            {
                var Bomb = (GameObject)Instantiate(
                BombPrefab,
                this.transform.position,
                this.transform.rotation);
                P2BombActive = true;
            }
        }

    }
}
