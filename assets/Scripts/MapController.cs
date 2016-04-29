using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

	GameObject t_1;
	GameObject t_2;
	GameObject t_3;
	GameObject t_4;

	public Transform town1;
	public Transform town2;
	public Transform town3;
	public Transform town4;

	// Use this for initialization
	void Start () {
		ApplicationModel.experience = 150;
		ApplicationModel.curr_zone = 2;
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
}
