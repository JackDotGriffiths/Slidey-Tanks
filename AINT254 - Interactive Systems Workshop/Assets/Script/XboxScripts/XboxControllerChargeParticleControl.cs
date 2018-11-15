using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxControllerChargeParticleControl : MonoBehaviour {
    public ParticleSystem ChargingParticles;
    private float shootAxis;
    private bool charging = false;

    void Update()
    {
        shootAxis = Input.GetAxis("Player2Fire");

        if (shootAxis > 0 && charging == false)
        {
            ChargingParticles.Play();
            charging = true;
        }
        if (shootAxis == 0 && charging == true)
        {
            ChargingParticles.Stop();
            charging = false;
        }
    }
}
