using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControllerRotate : MonoBehaviour {

 
    public float f_vertical;
    public float f_horizontal;


	// Update is called once per frame
	void Update () {
        f_vertical = Input.GetAxis("Player2Vertical") * 360;
        f_horizontal = Input.GetAxis("Player2Horizontal") * 360;

        Vector3 lookdirection = new Vector3(f_horizontal, transform.position.y, f_vertical);

        Quaternion targetRotation = Quaternion.LookRotation(lookdirection - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15 * Time.deltaTime);
    }
}
