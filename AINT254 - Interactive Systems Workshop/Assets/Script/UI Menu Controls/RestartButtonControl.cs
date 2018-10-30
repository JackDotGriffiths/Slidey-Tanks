using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButtonControl : MonoBehaviour {

    public Button restartButton;

	// Use this for initialization
	void Start () {
        Button button1 = restartButton.GetComponent<Button>();

        button1.onClick.AddListener(GoToMain);
    }

    // Update is called once per frame
    void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
}
