using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthControl : MonoBehaviour {

    public GameObject enemyBullet;
    public GameObject playerBullet;
    public GameObject PlayerTank;
    public GameObject explodeAnimation;
    public GameObject loseText;
    public GameObject buttonRestart;
    public AudioSource TankExplodeSound;
    public GameObject HealthBar2;
    public GameObject HealthBar3;
    public GameObject bulletDestroy;

    public Material TankMetalMaterial;

    private float TankHealth;
    private bool HealthLost = false;
    private bool dealdamage = false;

    void Start()
    {
        TankHealth = 3;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerBullet.tag)
        {
            Destroy(other.gameObject);
            var destroyParticles = (GameObject)Instantiate(
            bulletDestroy,
            other.gameObject.transform.position,
            other.gameObject.transform.rotation);

            Destroy(destroyParticles, 0.4f);
        }

        if (other.tag == enemyBullet.tag)
        {
            Destroy(other.gameObject);
            dealdamage = true;
         }
     }

    void Update()
    {
       if (dealdamage == true)
        {
            
            var destroyParticles = (GameObject)Instantiate(
            bulletDestroy,
            gameObject.transform.position,
            gameObject.transform.rotation);

            Destroy(destroyParticles, 0.4f);
            Debug.Log("Taking Health");
            TankHealth = TankHealth - 1f;
            if (TankHealth == 2)
            {
                HealthBar3.GetComponent<MeshRenderer>().material = TankMetalMaterial;
                HealthLost = false;
            }
            else if (TankHealth == 1)
            {
                HealthBar2.GetComponent<MeshRenderer>().material = TankMetalMaterial;
                HealthLost = false;

            }
            else if (TankHealth == 0)
            {
                TankExplodeSound.Play();
                foreach (Transform child in PlayerTank.transform)
                {
                    if (child.gameObject.name == "Tank" || child.gameObject.name == "Barrel")
                    {
                        child.gameObject.SetActive(false);
                    }
                }
                ExplodeTank();
            }
        }

        dealdamage = false;
    }

    void ExplodeTank()
    {
        Destroy(PlayerTank, .701f);
        var Explode = (GameObject)Instantiate(
            explodeAnimation,
            PlayerTank.transform.position,
            PlayerTank.transform.rotation);

        Explode.GetComponentInChildren<ParticleSystem>().Play();
        loseText.GetComponent<Text>().enabled = true;
        buttonRestart.GetComponent<Button>().enabled = true;
        buttonRestart.GetComponent<Image>().enabled = true;
        buttonRestart.GetComponentInChildren<Text>().enabled = true;

        Pause();
        Destroy(Explode, 2f);
    }

    void Pause()
    {
        PauseMenuControl.LockControls = true;
    }
}
