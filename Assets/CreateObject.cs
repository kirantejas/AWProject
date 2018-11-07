﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CarButtonCreate()
    {
        GameObject car;
        car = getInactiveGameObject("jeep");
        car.gameObject.SetActive(true);
    }

    public void CarButtonDestroy()
    {
        GameObject car;
        car = GameObject.Find("jeep");
        car.gameObject.SetActive(false);
    }

    public void ManButtonCreate()
    {
        GameObject man;
        man = getInactiveGameObject("BlueSuitFree01");
        man.gameObject.SetActive(true);
    }

    public void ManButtonDestroy()
    {
        GameObject man;
        man = GameObject.Find("BlueSuitFree01");
        man.gameObject.SetActive(false);
    }

    public void TreeButtonCreate()
    {
        GameObject tree;
        tree = getInactiveGameObject("Palm_Tree");
        tree.gameObject.SetActive(true);
    }

    public void TreeButtonDestroy()
    {
        GameObject tree;
        tree = GameObject.Find("Palm_Tree");
        tree.gameObject.SetActive(false);
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