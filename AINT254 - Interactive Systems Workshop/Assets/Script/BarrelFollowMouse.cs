using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFollowMouse : MonoBehaviour {
    public Vector3 RayHitPoint;
    void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            RayHitPoint = hit.point;
        }

        transform.LookAt(new Vector3(RayHitPoint.x, transform.position.y, RayHitPoint.z));

    }
}
