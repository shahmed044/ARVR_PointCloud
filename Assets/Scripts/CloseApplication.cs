using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseApplication : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Escape))
			//Application.Quit();
			SceneManager.LoadScene("MainMenu");
    }
}
