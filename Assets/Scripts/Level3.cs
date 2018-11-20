using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour {

    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;
    GameObject jeep;
    GameObject wheel;
    String alignment;
    public static bool isRotateJeep;
    public static bool isRotateWheel;

    // Use this for initialization
    void Start () {
        isRotateJeep = false;
        isRotateWheel = false;
        startTime = DateTime.Now;
        alignment = "left";
        if (alignment.Trim().Equals("left"))
        {
            GameObject[] btns = GameObject.FindGameObjectsWithTag("movableButton");
            foreach (GameObject btn in btns)
            {
                btn.transform.Translate(new Vector3(-800, 0, 0));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (isRotateJeep)
        {
            jeep = GameObject.Find("greenjeep");
            jeep.transform.Rotate(new Vector3(0, Time.deltaTime * 500, 0)); 
        }

        if (isRotateWheel)
        {
            wheel = GameObject.Find("WheelBall");
            wheel.transform.Rotate(new Vector3(0, Time.deltaTime * 500, 0));
        }
    }

    public void RotateCar()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 3, 1, 0));
        isRotateJeep = true;
    }
    public void StopCar()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 3, 2, 0));
        isRotateJeep = false;
    }
    public void RotateWheel()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 3, 3, 0));
        isRotateWheel = true;
    }
    public void StopWheel()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 3, 4, 0));
        isRotateWheel = false;
    }

    public void onClickPrevious()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 3, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("Level2");
    }

    public void onClickHome()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 3, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("WelcomeScreen");
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
        GameObject window = getInactiveInCanvas("popupAim");
        window.SetActive(true);
    }

    public void onClickNext()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 3, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("Level4");
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
    IEnumerator MakeApiRequest(int UserId, int Level, int BtnId, int IsExercise)
    {


        WWWForm Form = new WWWForm();
        Form.AddField("user_id", UserId);
        Form.AddField("level", Level);
        Form.AddField("btn_id", BtnId);
        Form.AddField("is_exercise", IsExercise);
        WWW CreateAccountWww = new WWW(url + "btnclicks", Form);
        yield return CreateAccountWww;

        if (CreateAccountWww.error != null)
        {
            Debug.LogError("Cannot connect to Account creation");
        }
        else
        {
            string CreateAccountReturn = CreateAccountWww.text;
            if (CreateAccountReturn == "success")
            {
                Debug.Log("Success: Btn log entry");

            }
        }

    }
    #endregion
}
