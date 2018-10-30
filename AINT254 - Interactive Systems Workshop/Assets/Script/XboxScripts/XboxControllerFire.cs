using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XboxControllerFire : MonoBehaviour
{

    public GameObject tankBody;
    public GameObject Tank;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Image ReloadTimer;
    public AudioClip Shoot;
    public ParticleSystem smoke;

    public float shootAxis;



    void Update()
    {
        shootAxis = Input.GetAxis("Player2Fire");
        if (shootAxis>0)
        { 
            FireBullet();
        }

    }


    // Use this for initialization
    void FireBullet()
    {
        if (ReloadTimer.fillAmount == 1)
        {
            //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity. Destroy bullet after 5 seconds.
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 7;

            //Play the BarrelSmoke effect.
            smoke.Play();

            //Reset the reload timer to 0
            ReloadTimer.fillAmount = 0;

            //Play the firing noise
            GetComponent<AudioSource>().clip = Shoot;
            GetComponent<AudioSource>().Play();
            Tank.GetComponent<TankRecoil>().Recoil();

            //Destroy the bullet after 5 seconds
            Destroy(bullet, 5.0f);

        }
    }
}
