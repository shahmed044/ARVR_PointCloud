using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	static public int path;

	// Use this for initialization
	void Start () {
		
	} 
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetPath(int x)
	{
		Debug.Log("Setting path valude");
		path = x;
	}

	void OnDestroy()
	{
		Debug.Log("Gamestatus destroyed");
	}
}
