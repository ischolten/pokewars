using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	private int gold;
	private int points;
	private int strength;
	private int rank;
	private ArrayList items;

	// Use this for initialization
	void Start () {

		gold = 100;
		points = 2323;
		strength = 20;
		rank = 7;
		items = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getGold() {
		return gold;
	}

	public int getPoints() {
		return points;
	}

	public int getStrength() {
		return strength;
	}

	public int getRank() {
		return rank;
	}

	public ArrayList getItems() {
		return items;
	}

	public void buyItem(string name) {
		int cost = 0;
		if (name.Equals("Light Glove"))
		{
			cost = 300;
		}
		else if (name.Equals("Heavy Glove"))
		{
			cost = 500;
		}
		else if (name.Equals("Gothic Glove"))
		{
			cost = 750;
		}
		else if (name.Equals("Winter Glove"))
		{
			cost = 999;
		}
		else if (name.Equals("Quick Blast"))
		{
			cost = 20;
		}
		else if (name.Equals("Health Potion"))
		{
			cost = 50;
		}
		else if (name.Equals("Baby Oil"))
		{
			cost = 75;
		}
		else if (name.Equals("Ice Blast"))
		{
			cost = 100;
		}
		gold = gold - cost;
		items.Add (name);
	}
}
