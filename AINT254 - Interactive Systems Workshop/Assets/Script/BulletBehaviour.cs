using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour: MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        //Destroy bullet when it collides with walls.
        if(other.tag == "Walls")
        {
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}
