using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerMapSelectionControl : MonoBehaviour {

    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;
    public GameObject Map5;

    public Button btn_next;
    public Button btn_back;
    public Button btn_previous;

    private int MapIndex;

    // Use this for initialization
    void Start () {
        MapIndex = 1;
        btn_next.onClick.AddListener(DisplayNext);
        btn_previous.onClick.AddListener(DisplayPrevious);
        btn_back.onClick.AddListener(BackToMain);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DisplayNext();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisplayPrevious();
        }
    }
    void DisplayNext()
    {
        if (MapIndex == 5)
        {
            MapIndex = 1;
            ShowCanvas();
        }
        else
        {
            MapIndex += 1;
            ShowCanvas();
        }

    }

    void DisplayPrevious()
    {
        if (MapIndex == 1)
        {
            MapIndex = 5;
            ShowCanvas();
        }
        else
        {
            MapIndex -= 1;
            ShowCanvas();
        }
    }

    void BackToMain()
    {
        Debug.Log("BackToMain");
        SceneManager.LoadScene(0);
    }

    void ShowCanvas()
    {
        if (MapIndex == 1)
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
            Map3.SetActive(false);
            Map4.SetActive(false);
            Map5.SetActive(false);
        }
        else if(MapIndex == 2)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
            Map3.SetActive(false);
            Map4.SetActive(false);
            Map5.SetActive(false);
        }
        else if (MapIndex == 3)
        {
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(true);
            Map4.SetActive(false);
            Map5.SetActive(false);
        }
        else if (MapIndex == 4)
        {
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(false);
            Map4.SetActive(true);
            Map5.SetActive(false);
        }
        else if (MapIndex == 5)
        {
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(false);
            Map4.SetActive(false);
            Map5.SetActive(true);
        }
    }
}
