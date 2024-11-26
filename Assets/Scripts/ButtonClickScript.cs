using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void whenMapButtonClicked()
    {
        SceneManager.LoadScene("Map");
    }

    public void whenSampleButtonClicked()
    {
		SceneManager.LoadScene("menu");
	}

	public void whenBrowseButtonClicked()
	{
		Debug.Log("File broswer");
		SceneManager.LoadScene("Opening Scene");
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();
			//SceneManager.LoadScene("MainMenu");
	}

	// Update is called once per frame
	
}
