using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBehaviour : MonoBehaviour {

    public GameObject enemy;
    public Vector3 FireDirection;
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

    private void Update()
    {
        if (Time.time > Timer)
        {
            Timer = Time.time + TimerPeriod;
            RandomPos = new Vector3(Random.Range(-100f, 100f), TankBarrel.transform.position.y, Random.Range(-100f, 100f));
            Chance = Random.Range(1, 5);
        }
    }

    void FixedUpdate()
    {
        Debug.DrawLine(TankBarrel.transform.position, enemy.transform.position, Color.red);
        Vector3 enemyRotateTowards = new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z);

        RaycastHit hit;
        if (Physics.Linecast(TankBarrel.transform.position,enemy.transform.position, out hit))
        {
            Debug.DrawLine(TankBarrel.transform.position, hit.point, Color.cyan);
            if (hit.collider.tag == "Player1")
            {
                //Make the tank start braking if it can see the player.
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                rigidbody.velocity = new Vector3(rigidbody.velocity.x * 0.95f, rigidbody.velocity.y * 0.95f, rigidbody.velocity.z * 0.95f);
                Debug.DrawLine(TankBarrel.transform.position, enemyRotateTowards, Color.green);

                TankBarrel.transform.LookAt(hit.point);
                Invoke("Fire", 0.8f);
            }
            else if (hit.collider.tag == "Walls" || hit.collider.tag == "Untagged")
            {
                Quaternion rotation = Quaternion.LookRotation(RandomPos);
                TankBarrel.transform.rotation = Quaternion.Lerp(TankBarrel.transform.rotation, rotation, 6 * Time.deltaTime);
                Invoke("Fire", Chance);
            }

        }

        if (ReloadTimer.fillAmount < 1)
        {
            ReloadTimer.fillAmount += 0.02f;
        }

        PlaceBomb();

    }

    private void Fire()
    {
        if (ReloadTimer.fillAmount == 1)
        {
            if (Time.timeScale == 1)
            {
                //Instantiate bullet in position of bulletSpawn Game Object and give it a velocity.
                var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 7;

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

    void PlaceBomb()
    {
        if (BombPlaced == false && Chance == 1)
            {
                Debug.Log("PlaceBomb");
                var Bomb = (GameObject)Instantiate(
                AIBombPrefab,
                transform.position,
                transform.rotation);
                BombPlaced = true;
            }
    }
}
