using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change_Graph1 : MonoBehaviour {

    public RawImage img;
    public static int graphnum = 1;
    public WWW www1;
    public WWW www2;
    public WWW www3;
    public WWW www4;

    void Awake()
    {
        img = this.gameObject.GetComponent<RawImage>();
    }

    // Use this for initialization
    IEnumerator Start()
    {
        www1 = new WWW("https://i.ibb.co/vzYxPm5/Percentage-of-users-in-each-level.png");
        yield return www1;

        www2 = new WWW("https://i.ibb.co/whRGVNk/Time-spent-on-each-category-1.png");
        yield return www2;

        www3 = new WWW("https://i.ibb.co/bgh3cpp/Time-spent-on-each-tutorial.png");
        yield return www3;

        www4 = new WWW("https://i.ibb.co/8gMJJKf/Time-spent-on-each-exercise.png");
        yield return www4;
    }

    // Update is called once per frame
    void Update ()
    {
        if(graphnum == 1)
        {
            img.texture = www1.texture;
        }
        else if (graphnum == 2)
        {
            img.texture = www2.texture;
        }
        else if (graphnum == 3)
        {
            img.texture = www3.texture;
        }
        else if (graphnum == 4)
        {
            img.texture = www4.texture;
        }
    }

    public void ImageCreator(string url)
    {

    }

    public void onClickNext()
    {
        if (graphnum < 4)
        {
            graphnum++; 
        }
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    public void onClickPrevious()
    {
        if(graphnum > 1)
        {
            graphnum--;
        }
    }
}
