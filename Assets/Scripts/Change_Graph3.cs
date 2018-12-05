using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change_Graph3 : MonoBehaviour
{
    public RawImage img;
    public string levelSelected;
    public Text userLevel;

    void Awake()
    {
        img = this.gameObject.GetComponent<RawImage>();
    }

    // Use this for initialization
    IEnumerator Start()
    {
        WWW www = new WWW("https://i.ibb.co/8gMJJKf/Time-spent-on-each-exercise.png");
        yield return www;
        if (www != null && img != null)
        {
            img.texture = www.texture;
        }
        updateText();
    }

    public void updateText()
    {
        if (Assets.Scripts.globalClass.Level == 1)
        {
            levelSelected = "Basic";
        }
        else if (Assets.Scripts.globalClass.Level == 2)
        {
            levelSelected = "Intermediate";
        }
        else if (Assets.Scripts.globalClass.Level == 3)
        {
            levelSelected = "Advanced";
        }
        else
        {
            levelSelected = "Intermediate";
        }
        if (userLevel != null && levelSelected != null)
        {
            userLevel.text = "Your level: " + levelSelected;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void onClickNext()
    {

    }

    public void onClickHome()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    public void onClickPrevious()
    {
        SceneManager.LoadScene("StatsScreen 2");
    }
}
