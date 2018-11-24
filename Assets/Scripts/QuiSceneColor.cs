using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiSceneColor : MonoBehaviour {

    Camera cm;
    public Color green = new Color(0.2f, 0.4f, 0);
    public Color yellow = new Color(0.8f, 0.8f, 0);
    public Color red = new Color (0.5f, 0, 0);

    // Use this for initialization
    void Start () {
        cm = GetComponent<Camera>();
        
        if (buttonHandler.levelSelected == "Basic")
        {
            cm.backgroundColor = green;
        }
        if (buttonHandler.levelSelected == "Intermediate")
        {
            cm.backgroundColor = yellow;
        }
        if (buttonHandler.levelSelected == "Advanced")
        {
            cm.backgroundColor = red;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
