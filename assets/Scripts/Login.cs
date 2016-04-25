using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System; 
using System.Collections.Generic;

public class Login : MonoBehaviour {

    private InputField usernameInput;
    private InputField passwordInput;
	private HttpReq db;

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
			StartCoroutine(loginToDatabase(usernameInput.text, passwordInput.text));
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

	public IEnumerator loginToDatabase(string username, string password)
    {
		db = GameObject.Find("HttpReq").GetComponentInChildren<HttpReq>();
		WWW results = db.GET("http://70.46.202.195/pokewars/index.php/main/process/%20%7B%22command%22:%22login%22,%22username%22:%22"
			+ username + "%22,%22password%22:%22" + password + "%22%7D");
		yield return results;
	    char[] delimiterChars = { ' ', ',', '{', ':', '"' };
		string[] words = results.text.Split('"');
		Int32.TryParse (words [3], out ApplicationModel.id);
		ApplicationModel.name = words[7];
		Int32.TryParse(words[19],out ApplicationModel.experience);
		Int32.TryParse (words [23], out ApplicationModel.health);
		Int32.TryParse (words[27],out ApplicationModel.strength);
		Int32.TryParse(words[31],out ApplicationModel.speed);
		ApplicationModel.gold = 1000;
		UnityEngine.SceneManagement.SceneManager.LoadScene("Profile");
    }

    public void onClickRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }
}
