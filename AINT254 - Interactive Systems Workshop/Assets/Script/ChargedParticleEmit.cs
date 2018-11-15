using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargedParticleEmit : MonoBehaviour {
    public ParticleSystem ChargingParticles;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChargingParticles.Play();

        }
        if (Input.GetMouseButtonUp(0))
        {
            ChargingParticles.Stop();
        }
    }
}
