using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    private Text username;
    private Text password;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClick()
    {
        username = GameObject.Find("InputFieldUsername").GetComponent<Text>();
        password = GameObject.Find("InputFieldPassword").GetComponent<Text>();
        if(username) { Debug.Log("found Username"); }
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Welcome");
    }

    IEnumerator loginToDatabase(string username, string password)
    {
        string url = "70.46.202.195/pokewars/index.php/main/process/";
        string json = string.Format("{\"command\":\"login\",\"username\":\"%s\",\"password\":\"%s\"}", username, password);
        url += json;
        WWW www = new WWW(url);
        yield return www;

    }
}
