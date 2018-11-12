using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class buttonHandler : MonoBehaviour {

    private Button myButton_instructions;
    private Button myButton_play;
    private Button backButton;
    private Text instructions;


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
        SceneManager.LoadScene("TutorialHome");
    }
}