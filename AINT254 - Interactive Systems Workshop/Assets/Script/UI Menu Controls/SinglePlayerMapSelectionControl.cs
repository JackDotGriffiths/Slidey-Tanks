using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SinglePlayerMapSelectionControl : MonoBehaviour {

    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;

    public Button btn_next;
    public Button btn_previous;

    private int MapIndex;

    // Use this for initialization
    void Start () {
        MapIndex = 1;
        btn_next.onClick.AddListener(DisplayNext);
        btn_previous.onClick.AddListener(BackToMain);
    }

    void DisplayNext()
    {
        if (MapIndex < 4)
        {
            MapIndex += 1;
            ShowCanvas();
        }
        else if (MapIndex == 4)
        {
            MapIndex = 1;
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
        }
        else if(MapIndex == 2)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
            Map3.SetActive(false);
            Map4.SetActive(false);
        }
        else if (MapIndex == 3)
        {
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(true);
            Map4.SetActive(false);
        }
        else if (MapIndex == 4)
        {
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(false);
            Map4.SetActive(true);
        }

    }
}
