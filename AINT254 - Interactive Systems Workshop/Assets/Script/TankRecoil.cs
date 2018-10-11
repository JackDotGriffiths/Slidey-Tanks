using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRecoil : MonoBehaviour {
    public Vector3 mousePosition;
    public Rigidbody Tank;

    public Vector3 RayHitPoint;
    public Vector3 MouseTarget;
    public Vector3 recoilDirection;

	void Update () {
        GetMousePos();
		if (Input.GetMouseButtonDown(0))
        {
            Recoil();
        }
	}
    void GetMousePos()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            RayHitPoint = hit.point;
        }

        MouseTarget = new Vector3(RayHitPoint.x, transform.position.y, RayHitPoint.z);
    }
    void Recoil()
    {
        Tank.AddForce(-MouseTarget.normalized * 500);
    }
}
