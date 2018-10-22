﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TwoPlayerEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject tank;
    public GameObject tank2;
    public Light spotlight;

    private bool onHover = false;

    // Update is called once per frame
    void Update()
    {
        if (onHover == true)
        {
            tank.transform.Rotate(Vector3.up * Time.deltaTime * 80);
            tank2.transform.Rotate(Vector3.up * Time.deltaTime * 80);
            spotlight.enabled = true;
        }
        else
        {
            spotlight.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        onHover = false;
    }
}