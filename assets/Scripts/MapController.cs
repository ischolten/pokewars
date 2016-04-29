using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System; 
using System.Collections.Generic;

public class MapController : MonoBehaviour {

	GameObject t_1;
	GameObject t_2;
	GameObject t_3;
	GameObject t_4;

	public Transform town1;
	public Transform town2;
	public Transform town3;
	public Transform town4;

	HttpReq db;

	// Use this for initialization
	void Start () {
		
		if (ApplicationModel.experience < 100) {
			t_1 = GameObject.Find ("Town1/pin_been");
			t_2 = GameObject.Find ("Town2/pin_inactive");
			t_3 = GameObject.Find ("Town3/pin_inactive");
			t_4 = GameObject.Find ("Town4/pin_inactive");
			t_1.GetComponent<Renderer> ().enabled = true;
			t_2.GetComponent<Renderer> ().enabled = true;
			t_3.GetComponent<Renderer> ().enabled = true;
			t_4.GetComponent<Renderer> ().enabled = true;
			town2.GetComponent<Button>().interactable = false;
			town3.GetComponent<Button>().interactable = false;
			town4.GetComponent<Button>().interactable = false;
		} else if (ApplicationModel.experience < 200) {
			t_1 = GameObject.Find ("Town1/pin_been");
			t_2 = GameObject.Find ("Town2/pin_been");
			t_3 = GameObject.Find ("Town3/pin_inactive");
			t_4 = GameObject.Find ("Town4/pin_inactive");
			t_1.GetComponent<Renderer> ().enabled = true;
			t_2.GetComponent<Renderer> ().enabled = true;
			t_3.GetComponent<Renderer> ().enabled = true;
			t_4.GetComponent<Renderer> ().enabled = true;
			town3.GetComponent<Button>().interactable = false;
			town4.GetComponent<Button>().interactable = false;
		} else if (ApplicationModel.experience < 300) {
			t_1 = GameObject.Find ("Town1/pin_been");
			t_2 = GameObject.Find ("Town2/pin_been");
			t_3 = GameObject.Find ("Town3/pin_been");
			t_4 = GameObject.Find ("Town4/pin_inactive");
			t_1.GetComponent<Renderer> ().enabled = true;
			t_2.GetComponent<Renderer> ().enabled = true;
			t_3.GetComponent<Renderer> ().enabled = true;
			t_4.GetComponent<Renderer> ().enabled = true;
			town4.GetComponent<Button>().interactable = false;
		} else {
			t_1 = GameObject.Find ("Town1/pin_been");
			t_2 = GameObject.Find ("Town2/pin_been");
			t_3 = GameObject.Find ("Town3/pin_been");
			t_4 = GameObject.Find ("Town4/pin_been");
			t_1.GetComponent<Renderer> ().enabled = true;
			t_2.GetComponent<Renderer> ().enabled = true;
			t_3.GetComponent<Renderer> ().enabled = true;
			t_4.GetComponent<Renderer> ().enabled = true;
		}

		if (ApplicationModel.curr_zone == 1) {
			t_1.GetComponent<Renderer> ().enabled = false;
			t_1 = GameObject.Find ("Town1/pin_current");
			t_1.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 2) {
			t_2.GetComponent<Renderer> ().enabled = false;
			t_2 = GameObject.Find ("Town2/pin_current");
			t_2.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 3) {
			t_3.GetComponent<Renderer> ().enabled = false;
			t_3 = GameObject.Find ("Town3/pin_current");
			t_3.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 4) {
			t_4.GetComponent<Renderer> ().enabled = false;
			t_4 = GameObject.Find ("Town4/pin_current");
			t_4.GetComponent<Renderer> ().enabled = true;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectTown(int t) {
		StartCoroutine (getTownInfo (t));
		
		if (ApplicationModel.curr_zone == 1) {
			t_1.GetComponent<Renderer> ().enabled = false;
			t_1 = GameObject.Find ("Town1/pin_been");
			t_1.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 2) {
			t_2.GetComponent<Renderer> ().enabled = false;
			t_2 = GameObject.Find ("Town2/pin_been");
			t_2.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 3) {
			t_3.GetComponent<Renderer> ().enabled = false;
			t_3 = GameObject.Find ("Town3/pin_been");
			t_3.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 4) {
			t_4.GetComponent<Renderer> ().enabled = false;
			t_4 = GameObject.Find ("Town4/pin_been");
			t_4.GetComponent<Renderer> ().enabled = true;
		}

		ApplicationModel.curr_zone = t;
		Debug.Log ("Selected Zone " + ApplicationModel.curr_zone);
			
		if (t == 1) {
			t_1.GetComponent<Renderer> ().enabled = false;
			t_1 = GameObject.Find ("Town1/pin_current");
			t_1.GetComponent<Renderer> ().enabled = true;
		} else if (t == 2) {
			t_2.GetComponent<Renderer> ().enabled = false;
			t_2 = GameObject.Find ("Town2/pin_current");
			t_2.GetComponent<Renderer> ().enabled = true;
		} else if (t == 3) {
			t_3.GetComponent<Renderer> ().enabled = false;
			t_3 = GameObject.Find ("Town3/pin_current");
			t_3.GetComponent<Renderer> ().enabled = true;
		} else if (t == 4) {
			t_4.GetComponent<Renderer> ().enabled = false;
			t_4 = GameObject.Find ("Town4/pin_current");
			t_4.GetComponent<Renderer> ().enabled = true;
		}
		
	}

	public IEnumerator getTownInfo(int t) {
		db = GameObject.Find ("HttpReq").GetComponentInChildren<HttpReq> ();
		WWW results = db.GET ("http://70.46.202.195/pokewars/index.php/main/process/%20%7B%22command%22:%22loadmap%22,%22zone%22:%22"
		              + t + "%22,%22field%22:%22" + ApplicationModel.curr_field + "%22%7D");
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
