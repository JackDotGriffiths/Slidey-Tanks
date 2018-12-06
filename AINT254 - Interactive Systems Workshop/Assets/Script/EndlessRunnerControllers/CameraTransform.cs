using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour {

    [Range(5, 10)]
    public int BlockSpacing = 6;

    public static float CameraSpeed = 0.025f;

    public static float CameraAcceleration = 0.002f;

    [Range(.2f, 3)]
    public float TopSpeed = 2f;


    public static bool SpawnObstacles;
    

    private float OriginalPos;

    void Start()
    {
        OriginalPos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update () {
        
        if (CameraSpeed <= TopSpeed)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().pitch = 1 + (0.5f*CameraSpeed);
            CameraSpeed += CameraAcceleration * Time.deltaTime;
        }
        Vector3 newPos = new Vector3(transform.position.x + CameraSpeed, transform.position.y, transform.position.z);
        transform.position = newPos;
        if(transform.position.x >= OriginalPos+BlockSpacing)
        {
            Debug.Log("Spawn");
            SpawnObstacles = true;
            OriginalPos = this.transform.position.x;
        }


	}
}
