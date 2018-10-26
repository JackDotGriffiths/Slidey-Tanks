using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadControl : MonoBehaviour {

    public Image ReloadTimer;

    private void Update()
    {
        if (ReloadTimer.fillAmount < 1)
        {
            ReloadTimer.fillAmount += 0.01f;
        }
    }
}
