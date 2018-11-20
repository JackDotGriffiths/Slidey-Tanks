using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XboxControllerFire : MonoBehaviour
{
    public Image P2ShotChargedAmount;
    public GameObject tankBody;
    public GameObject Tank;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Image ReloadTimer;
    public AudioClip Shoot;
    public ParticleSystem smoke;
    public float shootAxis;
    public ParticleSystem ChargeShot;

    public static float bulletPower;

    private bool ReadyToFire = false;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            shootAxis = Input.GetAxis("Player2Fire");
            if (shootAxis > 0 && ReloadTimer.fillAmount >= 1)
            {
                ReadyToFire = true;
                //As the button is held down, increase the fillAmount by 0.02 and keep bulletPower = FillAmount
                P2ShotChargedAmount.fillAmount += 0.02f;
                bulletPower = P2ShotChargedAmount.fillAmount;
            }
            if (shootAxis == 0 && ReadyToFire == true)
            {
                P2ShotChargedAmount.fillAmount = 0f;
                ReadyToFire = false;
                FireBullet();
            }
        }
    }



    // Use this for initialization
    void FireBullet()
    {
        if (ReloadTimer.fillAmount == 1)
        {
            if (Time.timeScale == 1)
            {
                //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity. Destroy bullet after 5 seconds.
                var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 7;

                //Play the BarrelSmoke effect.
                smoke.Play();

                //Reset the reload timer to 0
                ReloadTimer.fillAmount = 0;

                //Play the firing noise
                GetComponent<AudioSource>().clip = Shoot;
                GetComponent<AudioSource>().Play();
                Tank.GetComponent<XboxControllerTankRecoil>().Recoil();

                //Destroy the bullet after 5 seconds
                Destroy(bullet, 5.0f);
            }
        }
    }
}

