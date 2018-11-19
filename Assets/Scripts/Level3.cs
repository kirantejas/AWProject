using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour {

    GameObject jeep;
    GameObject wheel;
    public static bool isRotateJeep;
    public static bool isRotateWheel;

    // Use this for initialization
    void Start () {
        isRotateJeep = false;
        isRotateWheel = false;
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
        isRotateJeep = true;
    }
    public void StopCar()
    {
        isRotateJeep = false;
    }
    public void RotateWheel()
    {
        isRotateWheel = true;
    }
    public void StopWheel()
    {
        isRotateWheel = false;
    }

    public void onClickPrevious()
    {
        SceneManager.LoadScene("Level2");
    }

    public void onClickHome()
    {
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
        SceneManager.LoadScene("Level4");
    }
}
