using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
