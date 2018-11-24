using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour {

    
	List<string> question = new List<string>(){"Member function of a class can ________", "Which among the following is not a necessary condition for \nconstructors?", "In which access should a constructor be defined, so that \nobject of the class can be created in any function?", "Which constructor is called while assigning some object \nwith another?", "Which type of constructor can’t have a return type?",
		"Which among the following is not a necessary condition for \nconstructors?", "How to access members of the class inside a member \nfunction?", "A member function can _______________ of the same \nclass", "Which member function doesn’t require any return type?", "Which among the following is not possible for \nmember function?",
		"How members of an object are accessed?", "Which definition best describes an object?", "Which specifier applies only to the constructors?", "Which of the following is not feature of pure OOP?", "Which among the following doesn’t come under OOP \nconcept?"
	}  ;

	public static int index;

	public static int count = 0;

	public static int nextQuestion = -1;

	public static List<string> correctAnswer = new List<string>(){"1", "3", "1", "3", "4", "4", "4", "1", "4", "3", "1", "1", "4", "3", "1"} ;

	public static string choiceSelected = "n";

	public static string selectedAnswer;

	public static string preventClicking = "n";

	public Transform resultObj;

	GameObject selectedAns, correctAns, scoreObj;

	public static int score = 0;

	List<int> listNumbers = new List<int>();

	// Use this for initialization
	void Start () {
        count = 0;
        nextQuestion = -1;
        score = 0;
		if (buttonHandler.levelSelected == "Basic") {
			index = -1;
			Debug.Log (index);
		}
		if (buttonHandler.levelSelected == "Intermediate") {
			index = 4;
		}
		if (buttonHandler.levelSelected == "Advanced") {
			Debug.Log ("check");
			index = 9;
		}
	}

	// Update is called once per frame
	void Update () {
		if (nextQuestion == -1) {
			index++;
			Debug.Log (question [index]);
			nextQuestion = 0;
		}
		if (nextQuestion == 0) {
			GetComponent<TextMesh> ().text = question [index];
        }
		if (preventClicking == "n") {
			if (choiceSelected == "y") {
				preventClicking = "y";
				choiceSelected = "n";
				count++;
				if (correctAnswer [index] == selectedAnswer) {
					score++;
					resultObj.GetComponent<TextMesh> ().text = "Correct!! Click Next to Continue.";
                    selectedAns = GameObject.Find (selectedAnswer);
					selectedAns.GetComponent<TextMesh> ().color = new Color (0, 1, 0);
					scoreObj = GameObject.Find ("Score");
					scoreObj.GetComponent<TextMesh> ().text = "Score : " + score;

                }  else {
					resultObj.GetComponent<TextMesh> ().text = "Incorrect!! Click Next to Continue.";
                    selectedAns = GameObject.Find (selectedAnswer);
					selectedAns.GetComponent<TextMesh> ().color = new Color (1, 0, 0, 1);
					correctAns = GameObject.Find (correctAnswer [index]);
					correctAns.GetComponent<TextMesh> ().color = new Color (0, 1, 0);
				}
			}
		}
	}
}

