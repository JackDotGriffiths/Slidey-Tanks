using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire: MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }


	// Use this for initialization
	void FireBullet () {
        var bullet = (GameObject)Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 7;

        Destroy(bullet, 5.0f);

    }
}
