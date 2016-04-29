using UnityEngine;
using System.Collections;

public class SceneChangeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void onGoToProfile()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Profile");
    }

    public void onGoToRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }

    public void onGoToWelcome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Welcome");
    }

	public void onGoToShop()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Store");
	}

	public void onGoToTown()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Town");
	}

	public void onGoToAccessories()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("StoreTab2");
	}

	public void onGoToMap()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
	}

    public void onMenu()
    {
        print("MENU");
        
    }
}
