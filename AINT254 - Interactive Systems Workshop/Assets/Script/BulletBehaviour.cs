using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour: MonoBehaviour {

    public GameObject destroyEffect;
    public GameObject bullet1;
    public GameObject bullet2;


    private void OnTriggerEnter(Collider other)
    {
        //Destroy bullet when it collides with walls.
        if(other.tag == "Walls" || other.tag == "Player1Bullet" || other.tag == "Player2Bullet")
        {
            var destroyParticles = (GameObject)Instantiate(
            destroyEffect,
            transform.position,
            transform.rotation);

            Destroy(destroyParticles, 0.4f);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}
