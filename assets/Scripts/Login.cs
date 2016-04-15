using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    private InputField usernameInput;
    private InputField passwordInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClickLogin()
    {
        GameObject usernametemp = GameObject.Find("InputFieldUsername");
        GameObject passwordtemp = GameObject.Find("InputFieldPassword");
        if(usernametemp)
        {
            usernameInput = usernametemp.GetComponent<InputField>();
        } 
        if(passwordtemp)
        {
            passwordInput = passwordtemp.GetComponent<InputField>();
        } 
        if (usernameInput.text != "" && passwordInput.text != "")
        {
            IEnumerator www = loginToDatabase(usernameInput.text, passwordInput.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Profile");
        }
        else if( usernameInput.text == "" && passwordInput.text == "")
        {
            Debug.Log("Please Enter username and password.");
        } else if(passwordInput.text == "" )
        {
            Debug.Log("Please Enter password.");
        } else
        {
            Debug.Log("Please Enter username.");
        }
        
    }

    IEnumerator loginToDatabase(string username, string password)
    {
        string url = "70.46.202.195/pokewars/index.php/main/process/";
        string json = string.Format("{\"command\":\"login\",\"username\":\"%s\",\"password\":\"%s\"}", username, password);
        url += json;
        WWW www = new WWW(url);
        yield return www;

    }

    public void onClickRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }
}
