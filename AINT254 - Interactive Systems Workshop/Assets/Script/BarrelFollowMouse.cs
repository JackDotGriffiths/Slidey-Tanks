using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFollowMouse : MonoBehaviour {
    public Vector3 RayHitPoint;
    public GameObject tankBody;

    void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            RayHitPoint = hit.point;
        }

        //Force the barrel to rotate towards the mouse pointer, only changing the Y axis so that it stays on a singular plane.
        transform.LookAt(new Vector3(RayHitPoint.x, transform.position.y, RayHitPoint.z));
    }
}
