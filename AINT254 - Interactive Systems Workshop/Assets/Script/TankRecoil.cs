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

        float ForceValue = 1 + BulletFire.bulletPower;
        Tank.AddForce(m_direction.normalized *800 * ForceValue);

        Debug.Log(ForceValue * 800);
    }
}
