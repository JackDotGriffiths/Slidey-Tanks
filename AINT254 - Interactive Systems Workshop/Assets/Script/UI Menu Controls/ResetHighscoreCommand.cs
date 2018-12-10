using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetHighscoreCommand : MonoBehaviour {

    public Text ButtonText;

    private int PressedTimes= 0;

    private void OnEnable()
    {
        ButtonText.text = "RESET HIGHSCORE";
        ButtonText.color = Color.white;
        PressedTimes = 0;
    }

    public void ButtonPress()
    {
      if (PressedTimes == 0)
        {
            ButtonText.text = "ARE YOU SURE?";
            ButtonText.color = Color.magenta;
            PressedTimes += 1;
        }
      else if (PressedTimes == 1)
        {
            ButtonText.text = "ARE YOU REALLY SURE?";
            ButtonText.color = Color.red;
            PressedTimes += 1;
        }
      else if (PressedTimes == 2)
        {
            ButtonText.text = "LAST CHANCE";
            PressedTimes += 1;
        }
        else if (PressedTimes == 3)
        {
            PlayerPrefs.DeleteAll();
            ButtonText.text = "Deleted.";
            PressedTimes += 1;
        }
    }
}
