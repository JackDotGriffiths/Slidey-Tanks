using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerPointer : MonoBehaviour {
    private LineRenderer laserOrigin;
    public Transform laserStart;
    public Transform laserEnd;
	// Use this for initialization
	void Start () {
        laserOrigin = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hitPoint;
        if (Physics.Raycast(laserStart.position, transform.forward, out hitPoint, 500))
        {
            Debug.DrawLine(laserStart.position, laserStart.position + transform.forward,Color.red);
            laserEnd.position = hitPoint.point;

            laserOrigin.SetPosition(0, laserStart.position);
            laserOrigin.SetPosition(1, laserEnd.position);

        }
    }
}
