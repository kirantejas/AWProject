using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;

public class Exercise1 : MonoBehaviour {

    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    GameObject car1;
    GameObject car2;
    GameObject window;
    public static bool isRotateCar1;
    public static bool isRotateCar2;
    float timeLeft = 30.0f;
    string order;
    public Button nextButton;

    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;

    // Use this for initialization
    void Start () {
        startTime = DateTime.Now;
        order = "";
        isRotateCar1 = false;
        isRotateCar2 = false;
        if (globalClass.HandPreference == 0)
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("movableButton");
            foreach (GameObject btn in btns)
            {
                btn.transform.Translate(new Vector3(-750, 0, 0));
            }
        }
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
    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            window = getInactiveInCanvas("popupHelp");
            window.SetActive(true);
            timeLeft = 30;
        }
        if (isRotateCar1)
        {
            car1 = GameObject.Find("greenjeep1");
            car1.transform.Rotate(new Vector3(0, Time.deltaTime * 500, 0));
        }

        if (isRotateCar2)
        {
            car2 = GameObject.Find("greenjeep2");
            car2.transform.Rotate(new Vector3(0, Time.deltaTime * 500, 0));
        }

        if(order.Length >= 4)
        {
            if (order.Substring(order.Length-4) == "2134")
            {
                nextButton.gameObject.SetActive(true);
            }
        }
    }

    public void RotateCar1()
    {
        isRotateCar1 = true;
        order += "1"; 
    }

    public void RotateCar2()
    {
        isRotateCar2 = true;
        order += "2";
    }

    public void StopCar1()
    {
        isRotateCar1 = false;
        order += "3";
    }

    public void StopCar2()
    {
        isRotateCar2 = false;
        order += "4";
    }

    public void onClickHome()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 5, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("WelcomeScreen");
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

    public void onClickNext()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 5, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("Exercise2");
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
