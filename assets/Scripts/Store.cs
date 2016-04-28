using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void buyItem(string name) {
		int cost = 0;
		if (name.Equals ("Light Glove")) {
			cost = 300;
		} else if (name.Equals ("Heavy Glove")) {
			cost = 500;
		} else if (name.Equals ("Gothic Glove")) {
			cost = 750;
		} else if (name.Equals ("Winter Glove")) {
			cost = 999;
		} else if (name.Equals ("Quick Blast")) {
			cost = 20;
		} else if (name.Equals ("Health Potion")) {
			cost = 50;
		} else if (name.Equals ("Baby Oil")) {
			cost = 75;
		} else if (name.Equals ("Ice Blast")) {
			cost = 100;
		}
		ApplicationModel.gold = ApplicationModel.gold - cost;
		ApplicationModel.items.Add (name);
	}
}
