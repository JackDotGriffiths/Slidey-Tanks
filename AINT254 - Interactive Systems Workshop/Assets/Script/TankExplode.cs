using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankExplode : MonoBehaviour {

    public GameObject enemyBullet;
    public GameObject PlayerTank;

    public GameObject explodeAnimation;
    public GameObject winText;
    public GameObject buttonRestart;
    public GameObject TankAudioSource;
    public AudioClip TankExplodeSound;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemyBullet.tag)
        {
            Debug.Log("Play Sound");
            TankAudioSource.GetComponent<AudioSource>().clip = TankExplodeSound;
            TankAudioSource.GetComponent<AudioSource>().PlayDelayed(0);
            ExplodeTank();
            Destroy(other);
        }
    }

    void ExplodeTank()
    {
        var Explode = (GameObject)Instantiate(
            explodeAnimation,
            PlayerTank.transform.position,
            PlayerTank.transform.rotation);

        Explode.GetComponentInChildren<ParticleSystem>().Play();
        winText.GetComponent<Text>().enabled = true;
        buttonRestart.GetComponent<Button>().enabled = true;
        buttonRestart.GetComponent<Image>().enabled = true;
        buttonRestart.GetComponentInChildren<Text>().enabled = true;


        Destroy(Explode, 2f);
        Destroy(PlayerTank);

    }
}
