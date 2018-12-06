using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObectCollisionForces : MonoBehaviour {


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        string ObjectTag;
        ObjectTag = other.tag;
        if(ObjectTag == "Player1" || ObjectTag == "Player2")
        {
            Rigidbody TankRigidbody;
            TankRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 Direction = other.gameObject.transform.position - this.transform.position;

            TankRigidbody.AddForce(Direction * 400);
            
        }
    }
}
