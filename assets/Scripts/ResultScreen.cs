using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {

	public Text goldNum;
	public Text xpNum;

	// Use this for initialization
	void Start () {
		goldNum = GameObject.Find("NumGold").GetComponent<Text>();
		xpNum = GameObject.Find("NumPoints").GetComponent<Text>();
		goldNum.text = ApplicationModel.goldDelta + "";
		xpNum.text = ApplicationModel.expDelta + "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
