using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercise2 : MonoBehaviour {

    public InputField input;
    private string enteredtext;

    // Checks if there is anything entered into the input field.
    
    void Start ()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update () {
		
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

}
