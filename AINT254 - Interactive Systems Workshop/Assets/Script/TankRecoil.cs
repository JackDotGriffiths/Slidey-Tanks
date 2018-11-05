using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankRecoil : MonoBehaviour {

    public Rigidbody Tank;
    public GameObject barrelEnd;

    private Vector3 m_direction;


    public void Recoil()
    {
        BulletFire bulletFire = GetComponent<BulletFire>();
        m_direction = Tank.transform.position - barrelEnd.transform.position;
        Tank.AddForce(m_direction.normalized * 2500 * (1 + BulletFire.bulletPower));
        Debug.Log(2000 * (1 + BulletFire.bulletPower));
    }
}
