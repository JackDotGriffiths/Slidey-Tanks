using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnePlayerEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject tank;
    public Quaternion ForwardDirection;
    public GameObject dirtParticles;

    private bool onHover = false;

    void Start() {
        ForwardDirection = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (onHover == true)
        {
            dirtParticles.SetActive(false);
            tank.transform.Rotate(Vector3.up * Time.deltaTime * 80);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        onHover = false;
        dirtParticles.SetActive(true);
        tank.transform.rotation = Quaternion.Slerp(transform.rotation, ForwardDirection, 5f);
    }
}
