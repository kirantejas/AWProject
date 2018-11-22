using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

	public static string levelSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		levelSelected = gameObject.name;
		Debug.Log (levelSelected);
		SceneManager.LoadScene ("QuizScene");
	}
}
