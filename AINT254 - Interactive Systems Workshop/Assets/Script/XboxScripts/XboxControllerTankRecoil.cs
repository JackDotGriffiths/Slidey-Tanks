using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControllerTankRecoil : MonoBehaviour {

	public Rigidbody Tank;
    public GameObject barrelEnd;

    private Vector3 m_direction;


    public void Recoil()
    {
        m_direction = Tank.transform.position - barrelEnd.transform.position;

        float ForceValue = 1 + XboxControllerFire.bulletPower;
        Tank.AddForce(m_direction.normalized * 1000 * ForceValue);
    }
}
