using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallControl : MonoBehaviour {

    private bool passedCamera = false;


	// Update is called once per frame
	void Update () {
	    if (this.GetComponent<MeshRenderer>().isVisible == true && passedCamera == false)
        {
            passedCamera = true;
        }
        else if (this.GetComponent<MeshRenderer>().isVisible == false && passedCamera == true)
        {
            Destroy(gameObject);
        }
    }
}
