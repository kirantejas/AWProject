using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour {
    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;

    // Use this for initialization
    void Start () {
        startTime = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GreenCarCreate()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 2, 1, 0));
        GameObject car;
        car = getInactiveGameObject("greenjeep");
        car.gameObject.SetActive(true);
    }

    public void GreenCarDestroy()
    {

        StartCoroutine(MakeApiRequest(globalClass.Id, 2, 2, 0));
        GameObject car;
        car = GameObject.Find("greenjeep");
        car.gameObject.SetActive(false);
    }

    public void OrangeCarCreate()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 2, 3, 0));
        GameObject car;
        car = getInactiveGameObject("orangejeep");
        car.gameObject.SetActive(true);
    }

    public void OrangeCarDestroy()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 2, 4, 0));
        GameObject car;
        car = GameObject.Find("orangejeep");
        car.gameObject.SetActive(false);
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

    public void onClickPrevious()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 2, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("Level1");
    }

    public void onClickHome()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 2, (int)timeDiff.TotalSeconds));

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
        StartCoroutine(LogLevelStats(globalClass.Id, 2, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("Level3");
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
            Debug.LogError("Cannot connect to Btn logs creation");
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
