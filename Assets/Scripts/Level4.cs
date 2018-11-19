using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;

public class Level4 : MonoBehaviour {

    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    public static bool isGreen;

    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;

    // Use this for initialization
    void Start () {
        isGreen = true;
        startTime = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void privateVariable()
    {
        GameObject window = getInactiveInCanvas("popup");
        StartCoroutine(MakeApiRequest(globalClass.Id, 4, 1, 0));
        window = getInactivePopup("popup");
        window.SetActive(true);
    }

    public void publicFunction()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 4, 2, 0));
        if (isGreen)
        {
            GameObject greencar;
            greencar = getInactiveGameObject("greenjeep");
            greencar.gameObject.SetActive(false);

            GameObject orangecar;
            orangecar = getInactiveGameObject("orangejeep");
            orangecar.gameObject.SetActive(true);

            isGreen = false;
        }
        else
        {
            GameObject orangecar;
            orangecar = getInactiveGameObject("orangejeep");
            orangecar.gameObject.SetActive(false);

            GameObject greencar;
            greencar = getInactiveGameObject("greenjeep");
            greencar.gameObject.SetActive(true);

            isGreen = true;
        }
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

    public void onClickPrevious()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 4, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("Level3");
    }

    public void onClickHome()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 4, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("WelcomeScreen");
    }

    public void onClickAim()
    {
        GameObject window = getInactiveInCanvas("popupAim");
        window.SetActive(true);
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