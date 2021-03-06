﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFollowMouse : MonoBehaviour {

    public Vector3 RayHitPoint;
    public GameObject tankBody;

    void Update () {

        if (PauseMenuControl.LockControls != true)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask layermask = 0 << 8;
            if (Physics.Raycast(ray, out hit))
            {
                RayHitPoint = hit.point;
            }

            //Force the barrel to rotate towards the mouse pointer, only changing the Y axis so that it stays on a singular plane.
            Vector3 lookDirection = new Vector3(RayHitPoint.x, transform.position.y, RayHitPoint.z);

            Quaternion targetRotation = Quaternion.LookRotation(lookDirection - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 40 * Time.deltaTime);
        }
    }
}
