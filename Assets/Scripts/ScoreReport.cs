using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreReport : MonoBehaviour {
    private readonly string url = "http://ramesh8856.pythonanywhere.com/";

    // Use this for initialization
    void Start () {
        Debug.Log(Assets.Scripts.globalClass.Id);
        Debug.Log(Question.score);
        GetComponent<TextMesh> ().text = "Quiz is Complete. Your score is " + Question.score;
        if (buttonHandler.levelSelected == "Basic")
        {
            if (Question.score > 3)
            {
                buttonHandler.levelSelected = "Intermediate";
                Assets.Scripts.globalClass.Level = 2;
            }
        }
        else if (buttonHandler.levelSelected == "Intermediate")
        {
            if (Question.score > 3)
            {
                buttonHandler.levelSelected = "Advanced";
                Assets.Scripts.globalClass.Level = 3;
            }
            if (Question.score < 3)
            {
                buttonHandler.levelSelected = "Basic";
                Assets.Scripts.globalClass.Level = 1;
            }
        }
        else if (buttonHandler.levelSelected == "Advanced")
        {
            if (Question.score < 3)
            {
                buttonHandler.levelSelected = "Intermediate";
                Assets.Scripts.globalClass.Level = 2;
            }
        }
        StartCoroutine(MakeApiRequest(Assets.Scripts.globalClass.Id, Assets.Scripts.globalClass.Level, Question.score, 0));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Couroutiune

    IEnumerator MakeApiRequest(int UserId, int Level, int score, int time)
    {
        WWWForm Form = new WWWForm();
        Form.AddField("user_id", UserId);
        Form.AddField("level", Level);
        Form.AddField("score", score);
        Form.AddField("time", time);
        WWW CreateAccountWww = new WWW(url + "quizstats", Form);
        yield return CreateAccountWww;

        if (CreateAccountWww.error != null)
        {
            Debug.LogError("Cannot connect to Quiz stats");
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

