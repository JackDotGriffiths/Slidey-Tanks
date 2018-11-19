using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TwoPlayerEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject tank;
    public GameObject tank2;
    private Quaternion ForwardDirection;
    public GameObject dirtParticles1;
    public GameObject dirtParticles2;

    private bool onHover = false;

    void Start()
    {
        ForwardDirection = tank.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (onHover == true)
        {
            dirtParticles1.SetActive(false);
            dirtParticles2.SetActive(false);
            tank.transform.Rotate(Vector3.up * Time.deltaTime * 80);
            tank2.transform.Rotate(Vector3.up * Time.deltaTime * 80);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        onHover = false;
        tank.transform.rotation = Quaternion.Lerp(transform.rotation, ForwardDirection, 3f);
        tank2.transform.rotation = Quaternion.Lerp(transform.rotation, ForwardDirection, 3f);
        dirtParticles1.SetActive(true);
        dirtParticles2.SetActive(true);
    }
}
