using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRotate : MonoBehaviour {
    public int speed;
	// Update is called once per frame
	void Update () {
		//Rotate tank with A and D to allow player to change angle to create more efficient movement around the map.

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        }
	}
}
