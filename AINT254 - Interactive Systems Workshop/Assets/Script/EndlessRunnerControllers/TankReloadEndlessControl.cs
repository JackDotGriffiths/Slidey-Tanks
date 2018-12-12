using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankReloadEndlessControl : MonoBehaviour {

    public Image ReloadTimer;

    private void Update()
    {
        if (ReloadTimer.fillAmount < 1)
        {
            ReloadTimer.fillAmount += 2f * Time.deltaTime;
        }
    }
}
