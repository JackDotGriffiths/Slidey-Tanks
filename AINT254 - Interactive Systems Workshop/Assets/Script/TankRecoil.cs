using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankRecoil : MonoBehaviour {
    public Vector3 mousePosition;
    public Rigidbody Tank;
    private GameObject barrelEnd;

    public Vector3 RayHitPoint;
    public Vector3 MouseTarget;
    private Vector3 m_direction;


	void Update () {
        GetMousePos();
	}
    void GetMousePos()
    {
        var layermask = LayerMask.GetMask("WallIgnore");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,layermask))
        {
            RayHitPoint = hit.point;
        }

        MouseTarget = new Vector3(RayHitPoint.x, Tank.transform.position.y, RayHitPoint.z);
        m_direction = Tank.transform.position - MouseTarget;
    }
    public void Recoil()
    {
       Debug.Log("Recoil");
       Tank.AddForce(m_direction.normalized * 500);
    }
}
