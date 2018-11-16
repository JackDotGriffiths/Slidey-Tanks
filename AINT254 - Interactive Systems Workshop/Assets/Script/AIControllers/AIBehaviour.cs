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
        
    private float bulletPower = 0.5f;
    private bool Rotated = false;
    private float Timer = 0.0f;
    private float TimerPeriod = 1.0f;
    private Vector3 RandomPos;
    private Vector3 AccuracyEdited;
    private int RandomAccuracyAddition;

    public static bool BombPlaced = false;
    private int Chance = 0;

    void Update()
    {
        if (Time.time > Timer)
        {
            Timer = Time.time + TimerPeriod;
            RandomPos = new Vector3(Random.Range(-100f, 100f), TankBarrel.transform.position.y, Random.Range(-100f, 100f));
            Chance = Random.Range(0, 4);
            RandomAccuracyAddition = (Random.Range(-5, 5)/10);
        }
        Debug.DrawRay(this.transform.position, enemy.transform.position - this.transform.position);
        Vector3 enemyRotateTowards = new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z);

        RaycastHit hit;
        if (Physics.Linecast(transform.position, enemy.transform.position,out hit))
        {
            if (hit.collider.tag == "Player1")
            {
                TankBarrel.transform.LookAt(AccuracyEditor(enemyRotateTowards));
                Fire();
            }
            else
            {
                TankBarrel.transform.LookAt(RandomPos);
                Fire();
            }
        }

        if (ReloadTimer.fillAmount < 1)
        {
            ReloadTimer.fillAmount += 0.02f;
        }

        PlaceBomb();

    }

    Vector3 AccuracyEditor(Vector3 givenVector)
    {
        AccuracyEdited = new Vector3(givenVector.x + RandomAccuracyAddition, givenVector.y, givenVector.z + RandomAccuracyAddition);
        return AccuracyEdited;
    }


    void Fire()
    {
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
            Recoil();

            //Destroy the bullet object after 5 seconds.
            Destroy(bullet, 5.0f);

        }
    }

    void Recoil()
    {
        Vector3 direction = Tank.transform.position - bulletSpawn.transform.position;
        float ForceValue = 1 + BulletFire.bulletPower;
        Tank.GetComponent<Rigidbody>().AddForce(direction.normalized * 1200);
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
