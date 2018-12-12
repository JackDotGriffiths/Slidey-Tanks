using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObectCollisionForces : MonoBehaviour {


    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        string ObjectTag;
        ObjectTag = other.gameObject.tag;
        if (other.name != "Tank")
        {
            if (ObjectTag == "Player1" || ObjectTag == "Player2")
            {
                Debug.Log(other.name);
                Rigidbody TankRigidbody;
                TankRigidbody = other.GetComponent<Rigidbody>();
                Vector3 Direction = other.gameObject.transform.position - this.transform.position;

                TankRigidbody.AddForce(Direction * 50);
            }
        }
    }
}
