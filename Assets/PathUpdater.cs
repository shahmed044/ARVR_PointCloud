using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PathUpdater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*GameObject go = GameObject.Find("GameStatus");
		if (go == null)
		{
			Debug.LogError("Failed to detect Tirgger");
			this.enabled = false;
			return;
		}
		GameStatus gs = go.GetComponent<GameStatus>();
		GetComponent<Text>().text = "Path :" + gs.path;*/

		GetComponent<Text>().text = "Path :" + GameStatus.path;
	}
}
