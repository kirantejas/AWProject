﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GreenCarCreate()
    {
        GameObject car;
        car = getInactiveGameObject("greenjeep");
        car.gameObject.SetActive(true);
    }

    public void GreenCarDestroy()
    {
        GameObject car;
        car = GameObject.Find("greenjeep");
        car.gameObject.SetActive(false);
    }

    public void OrangeCarCreate()
    {
        GameObject car;
        car = getInactiveGameObject("orangejeep");
        car.gameObject.SetActive(true);
    }

    public void OrangeCarDestroy()
    {
        GameObject car;
        car = GameObject.Find("orangejeep");
        car.gameObject.SetActive(false);
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
}