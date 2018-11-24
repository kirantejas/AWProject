using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;

public class buttonHandler : MonoBehaviour {

    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    DateTime startTime;
    DateTime endTime;
    TimeSpan timeDiff;

    private Button myButton_instructions;
    private Button myButton_play;
    private Button backButton;
    private Text instructions;

    public static string levelSelected;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Button_OnClick()
    {
        Debug.Log("Instructions Button Clicked");
        startTime = DateTime.Now;
        StartCoroutine(MakeApiRequest(globalClass.Id, 0, 1, 0));
        myButton_instructions = GameObject.Find("Button").GetComponent<Button>();
        myButton_instructions.gameObject.SetActive(false);

        
        myButton_play = GameObject.Find("Button_Start Learning").GetComponent<Button>();
        myButton_play.gameObject.SetActive(false);

        backButton = getInactiveGameObject("Button_Back").GetComponent<Button>();
        backButton.gameObject.SetActive(true);

        instructions = getInactiveGameObject("Instructions").GetComponent<Text>();
        instructions.gameObject.SetActive(true);
    }

    public void backButton_OnClick()
    {
        Debug.Log("Back Button Clicked");
        timeDiff = DateTime.Now - startTime;
        StartCoroutine(LogLevelStats(globalClass.Id, 0, (int)timeDiff.TotalSeconds));

        backButton = getInactiveGameObject("Button_Back").GetComponent<Button>();
        backButton.gameObject.SetActive(false);

        instructions = getInactiveGameObject("Instructions").GetComponent<Text>();
        instructions.gameObject.SetActive(false);

        myButton_instructions = getInactiveGameObject("Button").GetComponent<Button>();
        myButton_instructions.gameObject.SetActive(true);

        myButton_play = getInactiveGameObject("Button_Start Learning").GetComponent<Button>();
        myButton_play.gameObject.SetActive(true);

    }

    public GameObject getInactiveGameObject(string objectName)
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

    public void onClickStartLearning()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 0, 2, 0));
        SceneManager.LoadScene("TutorialHome");
    }

    public void onClickStartExercise()
    {
        SceneManager.LoadScene("Exercise1");
    }

    public void onClickStartQuiz()
    {
        if (Assets.Scripts.globalClass.Level == 1)
        {
            levelSelected = "Basic";
            Question.index = -1;
            SceneManager.LoadScene("QuizScene");
        }
        else if (Assets.Scripts.globalClass.Level == 2)
        {
            levelSelected = "Intermediate";
            Question.index = 4;
            SceneManager.LoadScene("QuizScene");
        }
        else if (Assets.Scripts.globalClass.Level == 3)
        {
            levelSelected = "Advanced";
            Question.index = 9;
            SceneManager.LoadScene("QuizScene");
        }
        else
        {
            levelSelected = "Intermediate";
            Question.index = 4;
            SceneManager.LoadScene("QuizScene");
        }
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