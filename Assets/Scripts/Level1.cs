using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;

public class Level1 : MonoBehaviour
{
    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;

    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    // Use this for initialization
    void Start()
    {
        startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CarButtonCreate()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 1, 1, 0));
        GameObject car;
        car = getInactiveGameObject("jeep");
        car.gameObject.SetActive(true);
    }

    public void CarButtonDestroy()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 1, 2, 0));
        GameObject car;
        car = GameObject.Find("jeep");
        car.gameObject.SetActive(false);
       
    }

    public void ManButtonCreate()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 1, 3, 0));
        GameObject man;
        man = getInactiveGameObject("BlueSuitFree01");
        man.gameObject.SetActive(true);
    }

    public void ManButtonDestroy()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 1, 4, 0));
        GameObject man;
        man = GameObject.Find("BlueSuitFree01");
        man.gameObject.SetActive(false);
    }

    public void TreeButtonCreate()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 1, 5, 0));
        GameObject tree;
        tree = getInactiveGameObject("Palm_Tree");
        tree.gameObject.SetActive(true);
    }

    public void TreeButtonDestroy()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 1, 6, 0));
        GameObject tree;
        tree = GameObject.Find("Palm_Tree");
        tree.gameObject.SetActive(false);
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
        StartCoroutine(LogLevelStats(globalClass.Id, 1, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("TutorialHome");
    }

    public void onClickHome()
    {
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 1, (int)timeDiff.TotalSeconds));
        SceneManager.LoadScene("WelcomeScreen");

    }

    public void onClickAim()
    {
       
    }

    public void onClickNext()
    {
        
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 1, (int) timeDiff.TotalSeconds));
        SceneManager.LoadScene("Level2");

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