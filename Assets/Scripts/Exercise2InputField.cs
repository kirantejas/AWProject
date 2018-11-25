using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercise2InputField : MonoBehaviour {


    public InputField input;
    public Text text;
    public Button nextButton;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getText()
    {
        Debug.Log("Input Text" + input.text);
        if (input.text == "Car car1 = new Car();" || input.text == "Car car1=new Car();" || input.text == "Car car1= new Car();" || input.text == "Car car1 =new Car();")
        {
            GameObject car;
            car = getInactiveGameObject("orangejeep");
            car.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            input.text = "Incorrect Code!";
            input.textComponent.color = Color.red;
        }
    }
    
    public void clearText()
    {
        input.text = "";
        input.textComponent.color = Color.black;
        nextButton.gameObject.SetActive(false);
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
