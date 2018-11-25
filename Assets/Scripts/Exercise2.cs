using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exercise2 : MonoBehaviour {

    public InputField input;
    private string enteredtext;
    GameObject window;
    float timeLeft = 30.0f;

    // Checks if there is anything entered into the input field.

    void Start ()
    {
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
}
