using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxTankRotate : MonoBehaviour {

    private Vector3 lookdirection;
    public float f_vertical;
    public float f_horizontal;


    // Update is called once per frame
    void Update()
    {
        if(PauseMenuControl.LockControls != true)
        {
            f_vertical = Input.GetAxis("Player2Vertical2") * 360;
            f_horizontal = Input.GetAxis("Player2Horizontal2") * 360;

            lookdirection = new Vector3(f_horizontal, transform.position.y, f_vertical);

            Quaternion targetRotation = Quaternion.LookRotation(lookdirection - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
        }
    }
}
