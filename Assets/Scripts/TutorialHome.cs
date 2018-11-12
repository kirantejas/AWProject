using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickTutorial1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void onClickTutorial2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void onClickTutorial3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void onClickTutorial4()
    {
        SceneManager.LoadScene("Level4");
    }
}