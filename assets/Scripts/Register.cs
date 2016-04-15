using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Register : MonoBehaviour {
    private InputField usernameInput;
    private InputField passwordInput;
    private InputField passwordConfirmInput;
    private InputField emailInput;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClickRegister()
    {
        GameObject usernametemp = GameObject.Find("InputFieldUsername");
        GameObject passwordtemp = GameObject.Find("InputFieldPassword");
        GameObject passwordconfirmtemp = GameObject.Find("InputFieldPasswordConfirm");
        GameObject emailtemp = GameObject.Find("InputFieldEmail");

        usernameInput = usernametemp.GetComponent<InputField>();
        passwordInput = passwordtemp.GetComponent<InputField>();
        passwordConfirmInput = passwordconfirmtemp.GetComponent<InputField>();
        emailInput = emailtemp.GetComponent<InputField>();

        if(usernameInput.text != "" && passwordInput.text != "" && passwordConfirmInput.text != "" && emailInput.text != "" && passwordInput.text == passwordConfirmInput.text)
        {
            IEnumerator www = registerUser(usernameInput.text, passwordInput.text, emailInput.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Profile");
        }

    }

    IEnumerator registerUser(string username, string password, string email)
    {
        string url = "70.46.202.195/pokewars/index.php/main/process/";
        string json = string.Format("{\"command\":\"register\",\"username\":\"%s\",\"password\":\"%s\",\"email\":\"%s\"}", username, password, email);
        url += json;
        WWW www = new WWW(url);
        yield return www;
    }

    public void onClickBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Welcome");
    }
}
