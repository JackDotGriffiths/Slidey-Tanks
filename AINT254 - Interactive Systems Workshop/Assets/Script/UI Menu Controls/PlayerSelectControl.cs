using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectControl : MonoBehaviour {

    public Button m_OnePlayerSelect;
    public Button m_TwoPlayerSelect;
    public Button Quitgame;
    public Canvas m_UICanvas;

    public Scene Prototype;

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;

        
        //Retrieve width of Canvas
        float Width = m_UICanvas.GetComponent<RectTransform>().rect.width;

        //Set Width of button to half of the width of the canvas
        m_OnePlayerSelect.GetComponent<RectTransform>().sizeDelta= new Vector2(Width/2, m_OnePlayerSelect.GetComponent<RectTransform>().rect.height);
        m_TwoPlayerSelect.GetComponent<RectTransform>().sizeDelta = new Vector2(Width/2, m_TwoPlayerSelect.GetComponent<RectTransform>().rect.height);


        Button button1 = m_OnePlayerSelect.GetComponent<Button>();
        Button button2 = m_TwoPlayerSelect.GetComponent<Button>();
        Button Quit = Quitgame.GetComponent<Button>();

        button1.onClick.AddListener(OnePlayerStart);
        button2.onClick.AddListener(TwoPlayerStart);
        Quit.onClick.AddListener(ExitGame);
	}
	
	// Update is called once per frame
	void OnePlayerStart()
    {
        Debug.Log("Start One Player");
        SceneManager.LoadScene(11);
    }

    void TwoPlayerStart()
    {
        Debug.Log("Start Two Player");
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
