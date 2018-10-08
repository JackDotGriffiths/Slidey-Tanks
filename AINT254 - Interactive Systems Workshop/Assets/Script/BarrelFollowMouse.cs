using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFollowMouse : MonoBehaviour {
    public Vector3 mousePosition;
	void Update () {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
