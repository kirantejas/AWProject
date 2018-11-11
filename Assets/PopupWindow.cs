using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{

	public GameObject window;
	public Text messageField;
	float delayTime = 10f;
	float timeElapsed;
	int check=0;
	// Use this for initialization

	void start(){
		
	}

	void update(){
		if (check == 0) {
			timeElapsed += Time.deltaTime;
			if (timeElapsed > delayTime) {
				check = 1;
				messageField.text = "hello world";
				window.SetActive (true);

			}
		}
	}
	public void Show(string message) {
		messageField.text = message;
		window.SetActive (true);
	}
		
	
	// Update is called once per frame
	public void Hide () {
		window.SetActive (false);
	}
}
