using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSettings : MonoBehaviour {

    public GameObject MainMenu1;
    public GameObject MainMenu2;
    public GameObject Settings;

    public void ShowSettingsCanvas()
    {
        MainMenu1.SetActive(false);
        MainMenu2.SetActive(false);
        Settings.SetActive(true);

    }
}
