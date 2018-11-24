using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrake : MonoBehaviour {
    [Range(0.8f, 0.999f)]
    public float BrakeValue = 0.9f;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x * BrakeValue, rigidbody.velocity.y * BrakeValue, rigidbody.velocity.z * BrakeValue) ;
        }
    }
}
