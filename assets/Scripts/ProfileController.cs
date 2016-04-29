using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System; 
using System.Collections.Generic;

public class ProfileController : MonoBehaviour {

	public Text hpTxt;
	public Text nameTxt;
	public Text spdTxt;
	public Text strTxt;
	public Text expTxt;
	public Text goldTxt;

	private HttpReq db;

	// Use this for initialization
	void Start () {
		hpTxt.text = ApplicationModel.health.ToString();
		nameTxt.text = ApplicationModel.name;
		spdTxt.text = ApplicationModel.speed.ToString();
		strTxt.text = ApplicationModel.strength.ToString();
		expTxt.text = ApplicationModel.experience.ToString ();
		goldTxt.text = ApplicationModel.gold.ToString ();
		if (EnemyModel.npcNum < 1) {
			StartCoroutine (getTownInfo ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator getTownInfo() {
		Debug.Log ("getting town info...");
		db = GameObject.Find ("HttpReq").GetComponentInChildren<HttpReq> ();
		WWW results = db.GET ("http://70.46.202.195/pokewars/index.php/main/process/%20%7B%22command%22:%22loadmap%22,%22zone%22:%22"
			+ ApplicationModel.curr_zone + "%22,%22field%22:%22" + ApplicationModel.curr_field + "%22%7D");
		yield return results;

		char[] delimiterChars = { ' ', ',', '{', ':', '"', '}'};
		string[] words = results.text.Split (delimiterChars);
		int j = 0;
		string[] newW = new string[20];
		for (int i = 0; i < words.Length; i++) {
			if (words [i].Length > 0) {
				newW [j] = words [i];
				j++;
			}
		}
		Int32.TryParse (newW[5], out EnemyModel.npcNum);
		Debug.Log ("numNPC: " + EnemyModel.npcNum);
	}
}
