using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfileController : MonoBehaviour {

	public Text hpTxt;
	public Text nameTxt;
	public Text spdTxt;
	public Text strTxt;

	// Use this for initialization
	void Start () {
		hpTxt.text = ApplicationModel.health.ToString();
		nameTxt.text = ApplicationModel.name;
		spdTxt.text = ApplicationModel.speed.ToString();
		strTxt.text = ApplicationModel.strength.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
