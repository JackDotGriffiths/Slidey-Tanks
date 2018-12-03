using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {

    private float playerscore = 0;
    public Text score;

	// Update is called once per frame
	void Update () {
        if (EndGameControl.GameOver == false)
        {
            playerscore += Time.deltaTime;
            score.text = playerscore.ToString("0000");
            PlayerPrefs.SetString("NewScore", score.text);
        }

        if (EndGameControl.GameOver == true)
        {
            int CurrentHighScore = int.Parse(PlayerPrefs.GetString("HighScore"));

            if (int.Parse(score.text) > CurrentHighScore)
            {
                //If the player beats the Highscore
                SaveHighscore();
            }
            else if (int.Parse(score.text) <= CurrentHighScore)
            {
                //If the player doesn't beat the Highscore
            }
        }
	}

    public void Name_Changed(string newText)
    {
        string name = newText;
    }

    private void SaveHighscore()
    {
        int CurrentHighScore = int.Parse(PlayerPrefs.GetString("HighScore"));


        

    }
}
