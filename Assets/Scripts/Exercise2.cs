using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Exercise2 : MonoBehaviour {

    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    public InputField input;
    private string enteredtext;
    GameObject window;
    float timeLeft = 30.0f;

    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;

    // Checks if there is anything entered into the input field.

    void Start ()
    {
        startTime = DateTime.Now;
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            window = getInactiveInCanvas("popupHelp");
            window.SetActive(true);
            timeLeft = 30;
        }
    }

    public void onValuechanged( )
    {
        enteredtext = input.text;
        Debug.Log(enteredtext);
        //if (input.text == "abcd")
        //{

        //    GameObject car;
        //    car = getInactiveGameObject("orangejeep");
        //    car.gameObject.SetActive(true);
        //}
    }

    public GameObject getInactiveGameObject(string objectName)
    {
        GameObject filedname = null;
        Transform[] trans = GameObject.Find("ARCamera").GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trans)
        {
            if (t.gameObject.name == objectName)
            {
                filedname = t.gameObject;
            }
        }
        return filedname;
    }
    public GameObject getInactiveInCanvas(string objectName)
    {
        GameObject filedname = null;

        Transform[] trans = GameObject.Find("Canvas").GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trans)
        {
            if (t.gameObject.name == objectName)
            {
                filedname = t.gameObject;
            }
        }
        return filedname;
    }
    public void onClickAim()
    {
        GameObject window1 = getInactiveInCanvas("popupAim");
        window1.SetActive(true);
    }
    public void onClickClose()
    {
        window.SetActive(false);
    }
    public void onOpenTutorial()
    {
        SceneManager.LoadScene("Level3");
    }
    public void onClickHome()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(Assets.Scripts.globalClass.Id, 6, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("WelcomeScreen");
    }


    public void onClickNext()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(Assets.Scripts.globalClass.Id, 6, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("WelcomeScreen");
    }
    #region Couroutiune

    IEnumerator LogLevelStats(int userId, int level, int time)
    {
        WWWForm Form = new WWWForm();
        Form.AddField("user_id", userId);
        Form.AddField("level", level);
        Form.AddField("time", time);
        WWW CreateAccountWww = new WWW(url + "levelstats", Form);
        yield return CreateAccountWww;

        if (CreateAccountWww.error != null)
        {
            Debug.LogError("Cannot connect to Level stats creation");
        }
        else
        {
            string CreateAccountReturn = CreateAccountWww.text;
            if (CreateAccountReturn == "success")
            {
                Debug.Log("Success: Level stats log entry");

            }
        }
    }
    #endregion
}
