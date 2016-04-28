using UnityEngine;
using System.Collections;

public class ShopLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickBack()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Profile");
	}

	public void onClickGloves()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Store");
	}

	public void onClickAccessories()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("StoreTab2");
	}

//	public void purchaseGlove1()
//	{
//		int gold = 300;
//	}
//
//	public void purchaseGlove2()
//	{
//		int gold = 500;
//	}
//
//	public void purchaseGlove3()
//	{
//		int gold = 750;
//	}
//
//	public void purchaseGlove4()
//	{
//		int gold = 999;
//	}
//
//	public void purchaseCharm1()
//	{
//		int gold = 300;
//	}
//
//	public void purchaseCharm2()
//	{
//		int gold = 500;
//	}
//
//	public void purchasePowerup1()
//	{
//		int gold = 750;
//	}
//
//	public void purchasePotion1()
//	{
//		int gold = 999;
//	}
}
