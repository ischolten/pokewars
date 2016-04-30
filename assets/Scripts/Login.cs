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

	public void register() {
		GameObject usernametemp = GameObject.Find("InputFieldUsername");
		ApplicationModel.name = usernametemp.GetComponent<InputField>().text;
		ApplicationModel.id = 5;
		ApplicationModel.experience = 0;
		ApplicationModel.gold = 10;
		ApplicationModel.health = 50;
		ApplicationModel.strength = 10;
		ApplicationModel.speed = 5;
		ApplicationModel.curr_zone = 1;
		ApplicationModel.curr_field = 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Profile");

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
		Debug.Log ("logging in...");
		db = GameObject.Find("HttpReq").GetComponentInChildren<HttpReq>();
		WWW results = db.GET("http://70.46.202.195/pokewars/index.php/main/process/%20%7B%22command%22:%22login%22,%22username%22:%22"
			+ username + "%22,%22password%22:%22" + password + "%22%7D");
		yield return results;
		string[] words = results.text.Split ('"');
		if (words.Length < 30) {
			Debug.Log ("incorrect login");
		} else {
			//char[] delimiterChars = { ' ', ',', '{', ':', '"' };

			Int32.TryParse (words [3], out ApplicationModel.id);
			ApplicationModel.name = words [7];
			Int32.TryParse (words [19], out ApplicationModel.experience);
			Int32.TryParse (words [23], out ApplicationModel.gold);
			Int32.TryParse (words [27], out ApplicationModel.health);
			Int32.TryParse (words [31], out ApplicationModel.strength);
			Int32.TryParse (words [35], out ApplicationModel.speed);
			Int32.TryParse (words [39], out ApplicationModel.curr_zone);
			Int32.TryParse (words [43], out ApplicationModel.curr_field);
			Debug.Log ("zone: " + ApplicationModel.curr_zone);
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Profile");
		}
    }


    public void onClickRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }
}
