using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour: MonoBehaviour {

    public GameObject destroyEffect;


    private void OnTriggerEnter(Collider other)
    {
        //Destroy bullet when it collides with walls.
        if(other.tag == "Walls")
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
