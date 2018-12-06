
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameControl : MonoBehaviour {

    public GameObject ExplosionParticles;
    public GameObject DestroyedTank;
    public static bool GameOver = false;
    public AudioSource tankExplode;

        
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathWall")
        {
            BlowUpTank();    
        }
    }

    public void BlowUpTank()
    {
        var Explosion = Instantiate(ExplosionParticles,
                transform.position,
                transform.rotation);

        var BrokenTank = Instantiate(DestroyedTank,
            transform.position,
            transform.rotation);

        tankExplode.Play();
        GameOver = true;
        StopCamera();
        DestroyTank();
    }
    public void DestroyTank()
    {
        MeshRenderer[] ObjectRenderers = GameObject.Find("PlayerOne - Endless Runner").GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer Object in ObjectRenderers){
            Destroy(Object.gameObject);
        }
        Invoke("DeleteTankFromScene", 1f);
    }

    public void StopCamera()
    {
        if (GameOver == true)
        {
            CameraTransform.CameraAcceleration = 0;
            CameraTransform.CameraSpeed = 0;
        }
    }
    public void DeleteTankFromScene()
    {
        Destroy(GameObject.Find("PlayerOne - Endless Runner"));
    }
}
