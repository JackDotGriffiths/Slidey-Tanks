using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInArea : MonoBehaviour {

    public static bool PlayerInArea = false;
    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            Debug.Log("InArea");
            PlayerInArea = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            PlayerInArea = false;
        }
    }
}
