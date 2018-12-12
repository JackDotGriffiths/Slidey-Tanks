using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlateAnim : MonoBehaviour {

    public Material Glow;
    public Material Plain;

    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;

    private int currentGlow = 1;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Start()
    {
        InvokeRepeating("GlowStep", 0, 0.5f);
    }

    private void GlowStep()
    {
        if (currentGlow < 4)
        {
            currentGlow += 1;
        }
        else if (currentGlow == 4)
        {
            currentGlow = 1;
        }
        SetGlow();
    }

    private void SetGlow()
    {
        if (currentGlow == 1)
        {
            Arrow1.GetComponent<MeshRenderer>().material = Glow;
            Arrow2.GetComponent<MeshRenderer>().material = Plain;
            Arrow3.GetComponent<MeshRenderer>().material = Plain;
            Arrow4.GetComponent<MeshRenderer>().material = Plain;
        }
        if (currentGlow == 2)
        {
            Arrow1.GetComponent<MeshRenderer>().material = Plain;
            Arrow2.GetComponent<MeshRenderer>().material = Glow;
            Arrow3.GetComponent<MeshRenderer>().material = Plain;
            Arrow4.GetComponent<MeshRenderer>().material = Plain;
        }
        if (currentGlow == 3)
        {
            Arrow1.GetComponent<MeshRenderer>().material = Plain;
            Arrow2.GetComponent<MeshRenderer>().material = Plain;
            Arrow3.GetComponent<MeshRenderer>().material = Glow;
            Arrow4.GetComponent<MeshRenderer>().material = Plain;
        }
        if (currentGlow == 4)
        {
            Arrow1.GetComponent<MeshRenderer>().material = Plain;
            Arrow2.GetComponent<MeshRenderer>().material = Plain;
            Arrow3.GetComponent<MeshRenderer>().material = Plain;
            Arrow4.GetComponent<MeshRenderer>().material = Glow;
        }
    }
}
