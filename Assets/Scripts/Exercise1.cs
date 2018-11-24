using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exercise1 : MonoBehaviour {

    GameObject car1;
    GameObject car2;
    GameObject window;
    public static bool isRotateCar1;
    public static bool isRotateCar2;
    float timeLeft = 5.0f;
    string order;
    bool show = true;
    // Use this for initialization
    void Start () {
        order = "";
        isRotateCar1 = false;
        isRotateCar2 = false;
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
    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && show)
        {
            window = getInactiveInCanvas("popupHelp");
            window.SetActive(true);
        }
        if (isRotateCar1)
        {
            car1 = GameObject.Find("greenjeep1");
            car1.transform.Rotate(new Vector3(0, Time.deltaTime * 500, 0));
        }

        if (isRotateCar2)
        {
            car2 = GameObject.Find("greenjeep2");
            car2.transform.Rotate(new Vector3(0, Time.deltaTime * 500, 0));
        }

        if(order.Length == 4)
        {
            if (order == "2134")
            {
                SceneManager.LoadScene("Exercise2");
            }
            order = "";
        }
    }

    public void RotateCar1()
    {
        isRotateCar1 = true;
        order += "1"; 
    }

    public void RotateCar2()
    {
        isRotateCar2 = true;
        order += "2";
    }

    public void StopCar1()
    {
        isRotateCar1 = false;
        order += "3";
    }

    public void StopCar2()
    {
        isRotateCar2 = false;
        order += "4";
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    public void onClickAim()
    {
        GameObject window1 = getInactiveInCanvas("popupAim");
        window1.SetActive(true);
    }
    public void onClickClose()
    {
        window.SetActive(false);
        show = false;
    }
    public void onOpenTutorial()
    {
        SceneManager.LoadScene("Level3");
    }
}
