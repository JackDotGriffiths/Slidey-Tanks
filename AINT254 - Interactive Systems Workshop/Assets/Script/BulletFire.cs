using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFire: MonoBehaviour {

    public static float bulletPower;


    public GameObject tankBody;
    public GameObject Tank;  
    public GameObject bulletPrefab;
    private Transform bulletSpawn;

    private Image ReloadTimer;
    private Image ShotChargedAmount;
    public AudioClip Shoot;
    public ParticleSystem smoke;
    public Animator BarrelBounce;

    public static bool FiredBullet;

    private void Start()
    {
        bulletSpawn = this.transform;
        ReloadTimer = GameObject.Find("BlueReload").GetComponent<Image>();
        ShotChargedAmount = GameObject.Find("BlueChargeShots").GetComponent<Image>();
        
    }


    void Update() {
        if (PauseMenuControl.LockControls != true)
        {
            if (Input.GetMouseButton(0) && ReloadTimer.fillAmount >= 1)
            {
                //As the button is held down, increase the fillAmount by 0.02 and keep bulletPower = FillAmount
                ShotChargedAmount.fillAmount += 0.02f;
                bulletPower = ShotChargedAmount.fillAmount;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //On Mouse release reset the fillAmount and run FireBullet.
                ShotChargedAmount.fillAmount = 0f;
                FireBullet();
            }
        }
    }


	// Use this for initialization
	void FireBullet () {
        if (ReloadTimer.fillAmount == 1)
        {
            if (Time.timeScale == 1)
            {
                //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity.
                var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 9 * (1 + bulletPower);

                //Run the Barrel Smoke Particle effect.
                smoke.Play();

                //Reset the ReloadTimer Object to an empty fillAmount
                ReloadTimer.fillAmount = 0;

                //Play the sound of bullet shooting.
                GetComponent<AudioSource>().clip = Shoot;
                GetComponent<AudioSource>().Play();
                BarrelBounce.Play("Bullet Recoil");
                BarrelBounce.Play("Idle");

                //Run the Recoil Method of TankRecoil script.
                Tank.GetComponent<TankRecoil>().Recoil();

                //Destroy the bullet object after 5 seconds.
                Destroy(bullet, 5.0f);
            }
        }
    }
}
