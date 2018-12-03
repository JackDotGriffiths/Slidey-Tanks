using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameControl : MonoBehaviour {

    public GameObject ExplosionParticles;
    public GameObject DestroyedTank;
    public static bool GameOver = false;

        
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
            new Vector3(transform.position.x + 2,transform.position.y + 1f,transform.position.z),
            transform.rotation);

        Destroy(gameObject);
        GameOver = true;
        StopCamera(); 
    }

    public void StopCamera()
    {
        if (GameOver == true)
        {
            CameraTransform.CameraAcceleration = 0;
            CameraTransform.CameraSpeed = 0;
        }
    }
}
