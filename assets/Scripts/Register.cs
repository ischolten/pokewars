using UnityEngine;
using System.Collections;

public class Register : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator registerUser(string username, string password, string email)
    {
        string url = "70.46.202.195/pokewars/index.php/main/process/";
        string json = string.Format("{\"command\":\"register\",\"username\":\"%s\",\"password\":\"%s\",\"email\":\"%s\"}", username, password, email);
        url += json;
        WWW www = new WWW(url);
        yield return www;
    }
}
