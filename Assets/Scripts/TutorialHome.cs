using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHome : MonoBehaviour {
    private readonly string url = "http://ramesh8856.pythonanywhere.com/";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickTutorial1()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 0, 3, 0));
        SceneManager.LoadScene("Level1");
    }

    public void onClickTutorial2()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 0, 4, 0));
        SceneManager.LoadScene("Level2");
    }

    public void onClickTutorial3()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 0, 5, 0));
        SceneManager.LoadScene("Level3");
    }

    public void onClickTutorial4()
    {
        StartCoroutine(MakeApiRequest(globalClass.Id, 0, 6, 0));
        SceneManager.LoadScene("Level4");
    }

    #region Couroutiune

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