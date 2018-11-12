using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour {

    public static bool isGreen;
    public GameObject window;
    public Text messageField;
	// Use this for initialization
	void Start () {
        isGreen = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void privateVariable()
    {
        //messageField.text = "Hello";
        window = getInactivePopup("popup");
        window.SetActive(true);
    }

    public void publicFunction()
    {
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
    public GameObject getInactivePopup(string objectName)
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
        SceneManager.LoadScene("Level3");
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("TutorialHome");
    }

    public void onClickAim()
    {

    }
}