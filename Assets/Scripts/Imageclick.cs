using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Imageclick : MonoBehaviour
{

	public Image img;

	public int pathValue;

	/*public void Start()
	{
		Debug.Log("In start of Imageclick");
		Debug.Log("1 In start of Imageclick pathValue : " + pathValue);
		pathValue = PlayerPrefs.GetInt("path", 0);
		Debug.Log("2 In start of Imageclick pathValue : " + pathValue);
	}

	public void OnDestroy()
	{
		Debug.Log("In destroy of Imageclick path : " + pathValue);
		PlayerPrefs.SetInt("path", pathValue);
	}*/
	public void LoadScene_1(string sceneName)
	{
		Debug.Log("In Load Scene 1");
		SceneManager.LoadScene(sceneName);
	}

	public void browseTrig() {
		

		PlayerPrefs.SetInt("path", -1);
		Debug.Log("pathvalue : "+ pathValue);
	}

	/*public void assignPath(int getPath)
	{
		Debug.Log("In assignPath");
	//	PlayerPrefs.SetInt("path", pathValue);
		pathValue = getPath;
		Debug.Log("path - assignPath:" + pathValue);
	}*/

	public void backTOMenu() {
		SceneManager.LoadScene("MainMenu");	
	}
	

}
