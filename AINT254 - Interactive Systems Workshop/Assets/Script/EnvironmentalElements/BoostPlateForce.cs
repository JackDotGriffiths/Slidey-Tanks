using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlateForce : MonoBehaviour {

    public GameObject fireTrail;
    public float period = 0.005f;

    private GameObject Tank;
    private float nextActionTime = 0.0f;
    private int TrailAmount = 0;
    private bool Emit = false;



    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        string CollisionTag = other.tag;
        if (CollisionTag == "Player1" || CollisionTag == "Player2")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 600);
            Emit = true;
            Tank = other.gameObject;
            TrailAmount = 0;
        }
    }

    private void Update()
    {
        if (TrailAmount < 100 && Emit == true)
        {
            Debug.Log(Tank.GetComponent<Rigidbody>().velocity.magnitude);
            if (Tank.GetComponent<Rigidbody>().velocity.magnitude > 15f)
            {
                var FireTrailParticles = Instantiate(fireTrail,
                new Vector3(Tank.transform.position.x,-0.07f,Tank.transform.position.z),
                Tank.transform.rotation);
                TrailAmount += 1;
                Destroy(FireTrailParticles, 1.5f);
            }
            else if (Tank.GetComponent<Rigidbody>().velocity.magnitude < 15f)
            {
                Emit = false;
            }
        }
    }
}
