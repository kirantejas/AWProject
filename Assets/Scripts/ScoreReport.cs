using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = "Quiz is Complete. Your score is " + Question.score; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
