using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour {
    Vector3 movement;
	// Use this for initialization
	void Start () {
        movement = new Vector3(20, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onMLClick()
    {
        //Vector3 test = Vector3
        GameObject jeep;
        jeep = GameObject.Find("jeep");
        jeep.transform.Translate(movement*Time.deltaTime);
    }
}
