﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFire: MonoBehaviour {

    public GameObject tankBody;
    public GameObject Tank;  
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Image ReloadTimer;

    public static bool FiredBullet;

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
   
    }


	// Use this for initialization
	void FireBullet () {
        if (ReloadTimer.fillAmount == 1)
        {
            //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity. Destroy bullet after 5 seconds.
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 7;
            ReloadTimer.fillAmount = 0;
            Tank.GetComponent<TankRecoil>().Recoil();
            Destroy(bullet, 5.0f);
            
        }
    }
}
