using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoogleApi : MonoBehaviour {

    public RawImage img;

    string url;

    public float lat;
    public float lon;

    LocationInfo li;

    public int zoom = 4;
    public int mapWidth = 640;
    public int mapHeight = 640;


    public string mapType;
    //public mapType mapSelected;
    public int scale = 7;
    // Use this for initialization
    IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapType +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyDs5-hb1eQy-jjJYdekK-Vg1cDD3pvhDzM";
        WWW www = new WWW(url);
        yield return www;

        img.texture = www.texture;
        img.SetNativeSize();

    }

    public void onb1click()
    {

    }

    public void onb2click()
    {

    }

    public void onb3click()
    {

    }

    public void onb4click()
    {

    }


    void Start () {
        img = this.gameObject.GetComponent<RawImage>();
        StartCoroutine(Map());
    }
	
	// Update is called once per frame
	void Update () {
		
	}




}
