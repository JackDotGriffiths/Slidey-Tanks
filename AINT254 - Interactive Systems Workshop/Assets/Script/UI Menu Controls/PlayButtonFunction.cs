﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayButtonFunction : MonoBehaviour {

    public int SceneToLoad;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(GoToScene);
	}
	
	// Update is called once per frame
	void GoToScene () {
        SceneManager.LoadScene(SceneToLoad);
	}
}
