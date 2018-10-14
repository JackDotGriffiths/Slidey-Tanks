using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankRecoil : MonoBehaviour {
    public Vector3 mousePosition;
    public Rigidbody Tank;

    public Vector3 RayHitPoint;
    public Vector3 MouseTarget;


	void Update () {
        GetMousePos();
	}
    void GetMousePos()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            RayHitPoint = hit.point;
        }

        MouseTarget = new Vector3(RayHitPoint.x, RayHitPoint.y, RayHitPoint.z);
    }
    public void Recoil()
    {
       Debug.Log("Recoil");
       Tank.AddForce(-MouseTarget.normalized * 500);
    }
}
