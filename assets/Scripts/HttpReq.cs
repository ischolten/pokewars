using System; 
using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 

/*
 * connects to the server and help make server calls 
 */

class HttpReq : MonoBehaviour
{   

	void Start(){}


	//retrieves information with given urls
	public WWW GET(string url)
	{

		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
		return www; 
	}

	//updates information with given urls 
	public WWW POST(string url, Dictionary<string,string> post)
	{
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<String,String> post_arg in post)
		{
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForRequest(www));
		return www; 
	}

	private IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
		
}
