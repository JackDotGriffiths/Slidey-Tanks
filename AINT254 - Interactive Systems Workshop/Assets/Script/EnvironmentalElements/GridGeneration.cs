using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour {

    Renderer rend;
    float scrollSpeed;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        scrollSpeed = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex",new Vector2(offset, 0));
    }
}
