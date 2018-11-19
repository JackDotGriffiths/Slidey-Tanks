using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour: MonoBehaviour {

    public GameObject destroyEffect;


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

    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);

        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            var destroyParticles = (GameObject)Instantiate(
            destroyEffect,
            transform.position,
            transform.rotation);

            Destroy(destroyParticles, 0.4f);
            Destroy(gameObject);
        }
    }
}
