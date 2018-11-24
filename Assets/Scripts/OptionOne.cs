using System.Collections; using System.Collections.Generic; using UnityEngine;  public class OptionOne : MonoBehaviour {  	List<string> option1 = new List<string>(){"Access all the members of the class", "Its name must be same as that of class", "Public", "Default", "Default", "Its name must be same as that of class", "Using this pointer only", "Call other member functions", "Static", "Access protected members of parent class", 		"Using dot operator/period symbol", "Instance of a class", "Public", "Classes must be used", "Platform independent" 	}  ;   	// Use this for initialization 	void Start () {
        //		GetComponent<TextMesh> ().text = option1 [0];
    }  	// Update is called once per frame 	void Update () {
        if (Question.index > -1)
        {
            GetComponent<TextMesh>().text = option1[Question.index];         }
    }  	void OnMouseDown(){ 		if (Question.preventClicking == "n") { 			Question.selectedAnswer = gameObject.name; 			Question.choiceSelected = "y"; 		} 	} }  