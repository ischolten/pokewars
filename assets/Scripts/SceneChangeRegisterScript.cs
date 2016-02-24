using UnityEngine;
using System.Collections;

public class SceneChangeRegisterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RegisterButtonClick()
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
}
