using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRToggle : MonoBehaviour
{

	void ToggleVR()
	{
		if (XRSettings.loadedDeviceName == "Cardboard")
		{
			StartCoroutine(LoadDevice("None"));
		}
		else
		{
			StartCoroutine(LoadDevice("Cardboard"));
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ToggleVR();
		}
	}

	// Update is called once per frame
	IEnumerator LoadDevice(string newDevice)
	{
		XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		XRSettings.enabled = true;
	}
}

