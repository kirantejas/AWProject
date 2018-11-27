using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class Login : MonoBehaviour {
 #region Variables
    // static
    public static string Email = "";
    public static string Password = "";
    

    //public
    public string currentMenu = "Login";

    //private
    private string CreateAccountUrl = "http://ramesh8856.pythonanywhere.com/signup";
    private string LoginUrl = "http://ramesh8856.pythonanywhere.com/login";
    private GUIStyle Heading;
    private GUIStyle Label;

    public string NEmail = "";
    public string NPassword = "";
    public string NCPassword = "";
    public string HandPreference = "";
    public string Age = "";

    //GUI test
    public float X;
    public float Y;
    public float Width;
    public float Height;

 #endregion
    // Use this for initialization
    void Start () {
        

    }

    void OnGUI() {
        GUI.skin.textField.fontSize = 50;

        GUI.skin.button.fontSize = 50;

        Heading = new GUIStyle();
        Heading.fontSize = 60;

        Label = new GUIStyle();
        Label.fontSize = 50;

        //Label.border = ;
        //Label.

        if (currentMenu == "Login")
        {
            LoginGUI();
        }else if(currentMenu == "CreateAccount")
        {
            CreateAccountGUI();
        }
    }

    #region Custom methods
    void LoginGUI() {
        GUI.Box(new Rect(100, 20, Screen.width, Screen.height), "Login", Heading);
        if(GUI.Button(new Rect(100, 440, 370, 80), "Create Account"))
        {
            currentMenu = "CreateAccount";
        }

        if(GUI.Button(new Rect(550, 440, 150, 80), "Login"))
        {
            StartCoroutine("LoginInit");
        }

        GUI.Label(new Rect(100, 120, 150, 70), "Email:", Label);
        Email = GUI.TextField(new Rect(100, 190, (Screen.width / 2), 70), Email, 25);

        GUI.Label(new Rect(100, 280, 150, 50), "Password:", Label);
        Password = GUI.PasswordField(new Rect(100, 340, (Screen.width / 2) , 70), Password, "*"[0]);

    }

    public void SceneSwitcher()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    void CreateAccountGUI()
    {
        GUI.Box(new Rect(100, 20, Screen.width, Screen.height), "Create Account", Heading);
        

        GUI.Label(new Rect(100, 100, 150, 30), "Email:", Label);
        NEmail = GUI.TextField(new Rect(100, 160, (Screen.width / 2), 70), NEmail);

        GUI.Label(new Rect(100, 240, 150, 30), "Password:", Label);
        NPassword = GUI.PasswordField(new Rect(100, 300, (Screen.width / 2), 70), NPassword, "*"[0]);

        GUI.Label(new Rect(100, 380, 150, 30), "Confirm Password:", Label);
        NCPassword = GUI.PasswordField(new Rect(100, 440, (Screen.width / 2), 70), NCPassword, "*"[0]);

        GUI.Label(new Rect(100, 530, 140, 30), "Hand Preference", Label);
        HandPreference = GUI.TextField(new Rect(100, 590, (Screen.width / 2), 70), HandPreference);

        GUI.Label(new Rect(100, 670, 150, 30), "Age", Label);
        Age = GUI.TextField(new Rect(100, 730, (Screen.width / 2), 70), Age);

        if (GUI.Button(new Rect(100, 840, 380, 100), "Create Account")) { 
        
            //currentMenu = "CreateAccount";
            if (NPassword == NCPassword)
            {
                StartCoroutine("CreateAccount");
            }
            else
            {
                //StartCoroutine();
            }
        }

        if (GUI.Button(new Rect(560, 840, 140, 100), "Back"))
        {
            currentMenu = "Login";
        }

        
    }

    #endregion
#region Couroutiune
    IEnumerator CreateAccount() {
        WWWForm Form = new WWWForm();
        Form.AddField("Email", NEmail);
        Form.AddField("Password", NPassword);
        Form.AddField("Age", Age);
        Form.AddField("HandPreference", HandPreference);
        WWW CreateAccountWww = new WWW(CreateAccountUrl, Form);
        yield return CreateAccountWww;

        if(CreateAccountWww.error != null)
        {
            Debug.LogError("Cannot connect to Account creation");
        }
        else
        {
            string CreateAccountReturn = CreateAccountWww.text;
            if (CreateAccountReturn == "Success")
            {   
                Debug.Log("Success: Account creation");
                currentMenu = "Login";
            }
        }
    }

    IEnumerator LoginInit()
    {
        Debug.Log("Init: Login");
        WWWForm Form = new WWWForm();
        Form.AddField("Email", Email);
        Form.AddField("Password", Password);
        WWW LoginWww = new WWW(LoginUrl, Form);
        yield return LoginWww;

        if (LoginWww.error != null)
        {
            Debug.LogError("Cannot connect to Login");
        }
        else
        {
            Debug.Log(LoginWww.text);
            string CreateAccountReturn = LoginWww.text;
            Response json = JsonConvert.DeserializeObject<Response>(CreateAccountReturn);
            if (json.status_code == 200)
            {
                Debug.Log("Success: Login");
                currentMenu = "Login";
                Assets.Scripts.globalClass.Id = json.id;
                Assets.Scripts.globalClass.Email = json.email;
                Assets.Scripts.globalClass.HandPreference = json.hand_preference;
                Assets.Scripts.globalClass.Age = json.age;
                Assets.Scripts.globalClass.Level = json.level;
                SceneSwitcher();
            }
        }
        Debug.Log("Before Sceneswitcher function");
    }

    #endregion

}

public class Response
{
    public int age { get; set; }
    public string email { get; set; }

    public int hand_preference { get; set; }
    public int id { get; set; }
    public int status_code { get; set; }
    public string text { get; set; }

    public int level { get; set; }

}
