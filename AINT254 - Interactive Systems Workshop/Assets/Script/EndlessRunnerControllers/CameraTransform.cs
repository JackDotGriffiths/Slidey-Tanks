using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour {

    [Range(5, 10)]
    public int BlockSpacing = 6;

    public static float CameraSpeed;
    public static bool SpawnObstacles;
    public static float CameraAcceleration;

    private float OriginalPos;

    void Start()
    {
        OriginalPos = this.transform.position.x;
        CameraSpeed = 0.03f;
        CameraAcceleration = 0.003f;
    }

    // Update is called once per frame
    void Update () {
        if(CameraSpeed <= 3f)
        {
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
