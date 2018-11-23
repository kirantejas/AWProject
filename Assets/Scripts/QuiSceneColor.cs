using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiSceneColor : MonoBehaviour {

    Camera cm;
    public Color yellow = Color.yellow;
    public Color blue = Color.blue;
    public Color magenta = Color.magenta;

    // Use this for initialization
    void Start () {
        cm = GetComponent<Camera>();
        
        if (SelectLevel.levelSelected == "Basic")
        {
            cm.backgroundColor = yellow;
        }
        if (SelectLevel.levelSelected == "Intermediate")
        {
            cm.backgroundColor = blue;
        }
        if (SelectLevel.levelSelected == "Advanced")
        {
            cm.backgroundColor = magenta;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
