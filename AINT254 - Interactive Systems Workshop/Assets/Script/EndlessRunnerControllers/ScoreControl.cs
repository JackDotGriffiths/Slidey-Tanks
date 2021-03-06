﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour {

    private float playerscore = 0;
    public Text score;
    public Text highscore;
    private int CurrentHighScore;
    private string CurrentHighScoreName; 
    private string NameToSave;

    private void Start()
    {
        PauseMenuControl.LockControls = false;
        CurrentHighScoreName = PlayerPrefs.GetString("CurrentHolder");
        CurrentHighScore = PlayerPrefs.GetInt("Highscore");
        highscore.text = CurrentHighScoreName + " - " + CurrentHighScore.ToString("0000");
    }

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update () {
        if (EndGameControl.GameOver == false)
        {
            playerscore += Time.deltaTime;
            score.text = playerscore.ToString("0000");
            PlayerPrefs.SetInt("NewScore", Mathf.RoundToInt(playerscore));
        }

        if (EndGameControl.GameOver == true)
        {
            if (Mathf.RoundToInt(playerscore) > CurrentHighScore)
            {
                //If the player beats the Highscore
                NewHighscoreEnd();
            }
            else if (Mathf.RoundToInt(playerscore) <= CurrentHighScore)
            {
                //If the player doesn't beat the Highscore
                OrdinaryEndGame();
            }
        }
	}

    public void Name_Changed(string newText)
    {
        NameToSave = newText;
    }

    private void OrdinaryEndGame()
    {
        PauseMenuControl.LockControls = true;
        GameObject.Find("BlueReload").GetComponent<Image>().enabled = false;
        GameObject.Find("BlueAmmoIcon").GetComponent<Image>().enabled = false;

        GameObject.Find("Game Over Text").GetComponent<Text>().enabled = true;

        GameObject.Find("BackgroundOverlay").GetComponent<Image>().enabled = true;

        Invoke("enableButtons", 1f);
    }
    private void NewHighscoreEnd()
    {
        PauseMenuControl.LockControls = true;
        GameObject.Find("BlueReload").GetComponent<Image>().enabled = false;
        GameObject.Find("BlueAmmoIcon").GetComponent<Image>().enabled = false;

        GameObject.Find("Game Over Text").GetComponent<Text>().enabled = true;

   

        GameObject.Find("Save Highscore").GetComponent<Button>().enabled = true;
        GameObject.Find("Save Highscore").GetComponent<Image>().enabled = true;
        GameObject.Find("Save Highscore").GetComponentInChildren<Text>().enabled = true;
        GameObject.Find("InputField").GetComponent<Image>().enabled = true;
        GameObject.Find("InputField").GetComponent<InputField>().enabled = true;
        GameObject.Find("InputField").GetComponentInChildren<Text>().enabled = true;
        GameObject.Find("InputNameText").GetComponent<Text>().enabled = true;

        GameObject.Find("NEWHIGHSCORE").GetComponent<Text>().enabled = true;

        GameObject.Find("BackgroundOverlay").GetComponent<Image>().enabled = true;
        Invoke("enableButtons", 1f);
    }


    public void enableButtons()
    {
        GameObject.Find("Retry").GetComponent<Button>().enabled = true;
        GameObject.Find("Retry").GetComponent<Image>().enabled = true;
        GameObject.Find("Retry").GetComponentInChildren<Text>().enabled = true;

        GameObject.Find("MainMenuButton").GetComponent<Button>().enabled = true;
        GameObject.Find("MainMenuButton").GetComponent<Image>().enabled = true;
        GameObject.Find("MainMenuButton").GetComponentInChildren<Text>().enabled = true;
    }

    public void SaveHighscore()
    {
        //When button is pressed & box has text in it - Save Highscore & name in player prefs - Update the display at the top - hide input and button

        if (NameToSave != null)
        {
            PlayerPrefs.SetString("CurrentHolder", NameToSave);
            PlayerPrefs.SetInt("Highscore", Mathf.RoundToInt(playerscore));

            CurrentHighScoreName = PlayerPrefs.GetString("CurrentHolder");
            CurrentHighScore = PlayerPrefs.GetInt("Highscore");
            highscore.text = CurrentHighScoreName + " - " + CurrentHighScore.ToString("0000");

            GameObject.Find("Save Highscore").SetActive(false);
            GameObject.Find("InputField").SetActive(false);
        }
    }
    public void Restart()
    {
        PauseMenuControl.LockControls = false;
        playerscore = 0;
        CameraTransform.CameraSpeed = 0.025f;
        CameraTransform.CameraAcceleration = 0.002f;
        EndGameControl.GameOver = false;
        GameObject.Find("BlueReload").GetComponent<Image>().enabled = true;
        GameObject.Find("BlueAmmoIcon").GetComponent<Image>().enabled = true;

        GameObject.Find("Game Over Text").GetComponent<Text>().enabled = true;

        GameObject.Find("Retry").GetComponent<Button>().enabled = false;
        GameObject.Find("Retry").GetComponent<Image>().enabled = false;
        GameObject.Find("Retry").GetComponentInChildren<Text>().enabled = false;

        GameObject.Find("MainMenuButton").GetComponent<Button>().enabled = false;
        GameObject.Find("MainMenuButton").GetComponent<Image>().enabled = false;
        GameObject.Find("MainMenuButton").GetComponentInChildren<Text>().enabled = false;


        GameObject.Find("Save Highscore").GetComponent<Button>().enabled = false;
        GameObject.Find("Save Highscore").GetComponent<Image>().enabled = false;
        GameObject.Find("Save Highscore").GetComponentInChildren<Text>().enabled = false;


        GameObject.Find("InputField").GetComponent<Image>().enabled = false;
        GameObject.Find("InputField").GetComponent<InputField>().enabled = false;
        GameObject.Find("InputField").GetComponentInChildren<Text>().enabled = false;
        GameObject.Find("InputNameText").GetComponent<Text>().enabled = false;

        GameObject.Find("BackgroundOverlay").GetComponent<Image>().enabled = false;

        GameObject.Find("NEWHIGHSCORE").GetComponent<Text>().enabled = false;
        Debug.Log("ReloadMap");
        SceneManager.LoadScene("EndlessRunner");
        Start();
    }
    public void MainMenu()
    {
        PauseMenuControl.LockControls = false;
        SceneManager.LoadScene(0);
    }
}
