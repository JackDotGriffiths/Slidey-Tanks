using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBehaviour : MonoBehaviour {

    public GameObject enemy;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public ParticleSystem smoke;
    public Image ReloadTimer;
    public AudioClip Shoot;
    public GameObject Tank;
    public GameObject TankBarrel;
    public GameObject AIBombPrefab;
        
    private float Timer = 0.0f;
    private float TimerPeriod = 1.0f;
    private Vector3 RandomPos;
    private Vector3 AccuracyEdited;

    public static bool BombPlaced = false;
    private int Chance = 0;

    private void Start()
    {
        InvokeRepeating("RandomGen", 1f, 1f);
    }

    void FixedUpdate()
    {
        Debug.DrawLine(TankBarrel.transform.position, enemy.transform.position, Color.red);
        RaycastHit hit;

        if (Physics.Linecast(transform.position,enemy.transform.position, out hit))
        {
            if (PauseMenuControl.LockControls == false)
            {
                if (hit.collider.tag == "Player1")
                {
                    //Make the tank start braking if it can see the player.
                    Rigidbody rigidbody = GetComponent<Rigidbody>();
                    rigidbody.velocity = new Vector3(rigidbody.velocity.x * 0.8f, rigidbody.velocity.y * 0.8f, rigidbody.velocity.z * 0.8f);

                    //Look at Player and fire.
                    Vector3 target = hit.point - transform.position;
                    Debug.DrawLine(transform.position, target, Color.gray);

                    TankBarrel.transform.rotation = Quaternion.Lerp(TankBarrel.transform.rotation, Quaternion.LookRotation(target), Time.deltaTime * 6);
                    Fire();

                    if (Random.value < .5)
                    {
                        Invoke("Fire", Chance);
                    }
                }
                else if (hit.collider.tag == "Walls" || hit.collider.tag == "Untagged")
                {
                   Invoke("FireTowardsPlayer",Chance/10);
                }
            }
        }
        if (ReloadTimer.fillAmount < 1)
        {
            ReloadTimer.fillAmount += 1.3f * Time.deltaTime;
        }
    }
    void RandomGen()
    {
        Timer = Time.deltaTime + TimerPeriod;
        RandomPos = new Vector3(Random.Range(-100f, 100f), TankBarrel.transform.position.y, Random.Range(-100f, 100f));
        Chance = Random.Range(1, 20);
    }
    void FireTowardsPlayer()
    {
        Vector3 enemyRotateTowards = new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z);
        Quaternion newrotation = Quaternion.LookRotation(-1 * enemyRotateTowards);
        TankBarrel.transform.rotation = Quaternion.Lerp(TankBarrel.transform.rotation, new Quaternion(0f, newrotation.y , 0f, 1f), 6 * Time.deltaTime);

        Fire();
    }
    void Fire()
    {
        if (ReloadTimer.fillAmount == 1 && PauseMenuControl.LockControls == false)
        {
            if (Time.timeScale == 1)
            {
                //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity.
                var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 10;

                //Run the Barrel Smoke Particle effect.
                smoke.Play();

                //Reset the ReloadTimer Object to an empty fillAmount
                ReloadTimer.fillAmount = 0;

                //Play the sound of bullet shooting.
                GetComponent<AudioSource>().clip = Shoot;
                GetComponent<AudioSource>().Play();

                //Run the Recoil Method of TankRecoil script.
                Recoil();

                //Destroy the bullet object after 5 seconds.
                Destroy(bullet, 5.0f);
            }

        }
    }
    void Recoil()
    {
        Vector3 direction = Tank.transform.position - bulletSpawn.transform.position;
        Tank.GetComponent<Rigidbody>().AddForce(direction.normalized * 1000);
    }
}
