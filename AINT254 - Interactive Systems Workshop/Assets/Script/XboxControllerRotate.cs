using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControllerRotate : MonoBehaviour {

    private Vector3 lookdirection;
    public float f_vertical;
    public float f_horizontal;


	// Update is called once per frame
	void Update () {
        f_vertical = Input.GetAxis("Player2Vertical") * 360;
        f_horizontal = Input.GetAxis("Player2Horizontal") * 360;

        lookdirection = new Vector3(f_horizontal, transform.position.y, f_vertical);

        transform.LookAt(lookdirection);
	}
}
