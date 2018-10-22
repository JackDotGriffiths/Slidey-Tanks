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
    public GameObject overlay;




    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemyBullet.tag)
        {
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
        overlay.GetComponent<Image>().enabled = true;
        Time.timeScale = 0;

        Destroy(PlayerTank);

    }
}
