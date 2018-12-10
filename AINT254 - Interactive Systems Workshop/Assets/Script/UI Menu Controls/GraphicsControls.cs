using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsControls : MonoBehaviour {

    private string chosenOption;

    private void OnEnable()
    {
        int QualityLevel = QualitySettings.GetQualityLevel();
        GetComponent<Dropdown>().value = QualityLevel;
    }

    public void TakeChoice(string choice)
    {
        chosenOption = choice;
        ChangeSettings();
    }

    public void ChangeSettings()
    {
        if (chosenOption == "Very Low")
        {
            QualitySettings.SetQualityLevel(0);
        }
        else if (chosenOption == "Low")
        {
            QualitySettings.SetQualityLevel(1);
        }
        else if (chosenOption == "Medium")
        {
            QualitySettings.SetQualityLevel(2);
        }
        else if (chosenOption == "High")
        {
            QualitySettings.SetQualityLevel(3);
        }
        else if (chosenOption == "Very High")
        {
            QualitySettings.SetQualityLevel(4);
        }
        else if (chosenOption == "Ultra")
        {
            QualitySettings.SetQualityLevel(5);
        }
    }
}
