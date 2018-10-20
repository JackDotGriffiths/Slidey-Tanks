using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFire: MonoBehaviour {

    public GameObject tankBody;
    public GameObject Tank;  
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Image ReloadTimer;
    public AudioClip Shoot;
    public ParticleSystem smoke;

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
            //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity.
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 7;

            //Run the Barrel Smoke Particle effect.
            smoke.Play();

            //Reset the ReloadTimer Object to an empty fillAmount
            ReloadTimer.fillAmount = 0;
            
            //Play the sound of bullet shooting.
            GetComponent<AudioSource>().clip = Shoot;
            GetComponent<AudioSource>().Play();

            //Run the Recoil Method of TankRecoil script.
            Tank.GetComponent<TankRecoil>().Recoil();

            //Destroy the bullet object after 5 seconds.
            Destroy(bullet, 5.0f);

        }
    }
}
