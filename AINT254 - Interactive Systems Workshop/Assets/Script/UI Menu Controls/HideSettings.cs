using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSettings : MonoBehaviour {

    public GameObject MainMenu1;
    public GameObject MainMenu2;
    public GameObject Settings;

    public void HideSettingsCanvas()
    {
        MainMenu1.SetActive(true);
        MainMenu2.SetActive(true);
        Settings.SetActive(false);

    }
}
