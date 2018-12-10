using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsControls : MonoBehaviour {
    private void OnEnable()
    {
        int QualityLevel = QualitySettings.GetQualityLevel();
        GetComponent<Dropdown>().value = QualityLevel;
    }

    public void TakeChoice(int choice)
    {
        Debug.Log(choice);
        QualitySettings.SetQualityLevel(choice);
    }
}
