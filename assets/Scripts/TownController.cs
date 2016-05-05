using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System; 
using System.Collections.Generic;

/*
 * controls the town and sets the NPCs
 */

public class TownController : MonoBehaviour {

	public Button e_1;
	public Button e_2;
	public Button e_3;

	GameObject t_1;
	GameObject t_2;
	GameObject t_3;
	GameObject t_4; 

	private HttpReq db;

	private Color npc_color;


	// sets up the background for different towns
	void Start () {
		t_1 = GameObject.Find ("hollowcrest");
		t_2 = GameObject.Find ("arrowvalley");
		t_3 = GameObject.Find ("windville");
		t_4 = GameObject.Find ("heartward");

		if (ApplicationModel.curr_zone == 1) {
			npc_color = new Color (115, 120, 233);
			t_1.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 2) {
			npc_color = new Color (22, 236, 138);
			t_2.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 3) {
			npc_color = new Color (236, 62, 63);
			t_3.GetComponent<Renderer> ().enabled = true;
		} else if (ApplicationModel.curr_zone == 4) {
			npc_color = Color.white;
			t_4.GetComponent<Renderer> ().enabled = true;
		}

		if (EnemyModel.npcNum == 1) {
			e_1.GetComponent<Image> ().color = npc_color;
			e_2.GetComponent<Image>().color = Color.clear;
			e_3.GetComponent<Image>().color = Color.clear;
		} else if (EnemyModel.npcNum == 2) {
			e_1.GetComponent<Image> ().color = npc_color;
			e_2.GetComponent<Image> ().color = npc_color;
			e_3.GetComponent<Image>().color = Color.clear;
		} else {
			e_1.GetComponent<Image>().color = npc_color;
			e_2.GetComponent<Image>().color = npc_color;
			e_3.GetComponent<Image>().color = npc_color;
		}
	
	}

	void Update () {
	
	}

	//retrieves NPC information based on the town

	public void beginBattle() {
		int min = (ApplicationModel.curr_zone - 1) * 5 + 1;
		int max = min + 4;
		int e_id = (int)UnityEngine.Random.Range (min, max);
		StartCoroutine(getNPC(e_id));
	}

	public IEnumerator getNPC(int e_id) {
		Debug.Log ("e_id: " + e_id);
		db = GameObject.Find("HttpReq").GetComponentInChildren<HttpReq>();
		WWW results = db.GET("70.46.202.195/pokewars/index.php/main/process/%20%7B%22command%22:%22loadNPC%22,%22npcID%22:%22"
			+ e_id + "%22%7D");
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
		Int32.TryParse (newW [5], out EnemyModel.health);
		Int32.TryParse (newW [7], out EnemyModel.experience);
		Int32.TryParse (newW [9], out EnemyModel.strength);
		Int32.TryParse (newW [13], out EnemyModel.speed);

		UnityEngine.SceneManagement.SceneManager.LoadScene ("Battle");
	}


}
