using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exercise1 : MonoBehaviour {

    GameObject car1;
    GameObject car2;
    public static bool isRotateCar1;
    public static bool isRotateCar2;
    float timeLeft = 5.0f;
    // Use this for initialization
    void Start () {
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
        if (timeLeft < 0)
        {
            GameObject window = getInactiveInCanvas("popupAim");
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
    }

    public void RotateCar1()
    {
        isRotateCar1 = true;
    }

    public void RotateCar2()
    {
        isRotateCar2 = true;
    }

    public void StopCar1()
    {
        isRotateCar1 = false;
    }

    public void StopCar2()
    {
        isRotateCar2 = false;
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    public void onClickAim()
    {

    }
    public void onOpenTutorial()
    {
        SceneManager.LoadScene("Level3");
    }
}
