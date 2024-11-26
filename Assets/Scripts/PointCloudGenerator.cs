using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using SimpleFileBrowser;
using UnityEngine.XR;

/// <summary>
/// Requests the user select a `.csv` file.
/// Reads the points from the file.
/// Splits the points into multiple children each of which is a PointCloud object with a portion of the points.
/// </summary>
public class PointCloudGenerator : MonoBehaviour
{
    public Material pointCloudMaterial;

    // maintained reference to the generated children (point cloud objects)
    private GameObject[] pointClouds;
    // the points read from the data file
    private List<Vector4> data;
    // the number of points read from the data file
    int numPoints = 0;
    // the number of point clouds that will be generated from the collection of points
    int numDivisions = 0;
    // the nubmer of points in each generated point cloud
    int numPointsPerCloud = 0;
    // The maximum number of vertices unity will allow per single mesh
    const int MAX_NUMBER_OF_POINTS_PER_MESH = 65000;


	//public int path ;

	private void Awake()
	{
		
	}


	void Start()
    {
		//path = PlayerPrefs.GetString("path1", "lol");
		// Open a native file dialog, so the user can specify the file location
		/*SFB.ExtensionFilter[] extensions = new[] { new ExtensionFilter("Point Cloud Files", "csv", "ply") };
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
        if (paths.Length < 1)
        {
            print("Error: Please specify a properly formatted CSV or binary PLY file.");
            Application.Quit();
            return;
        }*/

		/*GameObject go = GameObject.Find("Trigger");
		if (go == null)
		{
			Debug.LogError("Failed to detect Tirgger");
			this.enabled = false;
			return;
		}*/

		//Imageclick ic = go.GetComponent<Imageclick>();

		// path = ic.pathValue;
		//PlayerPrefs.SetString("path1", path);

		/*path = GameStatus.path;

		string filePath;

		Debug.Log("1 path:" + path);

		if (path == 0)
		{
			filePath = "/storage/emulated/0/Download/hansen_theatre__1hz_1000hz.csv";
		}
		else if (path == 1)
		{
			filePath = "/storage/emulated/0/Download/rueff_gallery_1hz_1000hz.csv";
		}
		else if (path == 2)
		{
			filePath = "/storage/emulated/0/Download/pao_sculture_studio__1hz_1000hz.csv";
		}
		else if (path == 3)
		{
			filePath = "/storage/emulated/0/Download/FPRD_stairwell_landing_2hz_500hz.csv";
		}
		else if (path == 4)
		{
			filePath = "/storage/emulated/0/Download/output.csv";
			Debug.Log("inside path assign path:" + path);
		}
		else if (path == 5)
		{
			filePath = "/storage/emulated/0/Download/output1.csv";
		}
		else if (path == 6)
		{
			filePath = "/storage/emulated/0/Download/output2.csv";
		}
		else if (path == 7)
		{
			filePath = "/storage/emulated/0/Download/output3.csv";
		}
		else if (path == -1) {
			filePath = FileBrowser.Result;
			Debug.Log("Filepath:" + filePath);
		}*/
		string filePath;
		//filePath = "/storage/emulated/0/Download/FPRD_stairwell_landing_2hz_500hz.csv";
		filePath = "C:\\Users\\HP\\Desktop\\sample_scans_101117\\sample_scans_101117\\hansen_theatre__1hz_1000hz.csv";



		//GetComponent<Text>().text = "path : " + filePath;
		Debug.Log("filePath: " + filePath);
		//string[] parts = filePath.Split('.');
		string extension ="csv";

        // Read the points from the file
        switch (extension)
        {
            case "csv":
            case "CSV":
                data = CSVReader.ReadPoints(filePath);
                break;
            case "ply":
            case "PLY":
                data = PLYReader.ReadPoints(filePath);
                break;
            default:
                print("Error: Please specify a properly formatted CSV or binary PLY file.");
                Application.Quit();
                return;
        }

        numPoints = data.Count;
		Debug.Log("numPoints: " + numPoints);
        if (numPoints <= 0)
        {
            print("Error: failed to read points from " + filePath);
            Application.Quit();
            return;
        }

        // Calculate the appropriate division of points
        numDivisions = Mathf.CeilToInt(1.0f * numPoints / MAX_NUMBER_OF_POINTS_PER_MESH);

        // For simplicity, only use a number of points that splits evenly among numDivisions pointclouds
        numPoints -= numPoints % numDivisions;
        numPointsPerCloud = numPoints / numDivisions;

        print("" + numPoints + " points, split into " + numDivisions + " clouds of " + numPointsPerCloud + " points each.");

        pointClouds = new GameObject[numDivisions];

        // generate point cloud objects, each with the same number of points
        for (int i = 0; i < numDivisions; i++)
        {
            int offset = i * numPointsPerCloud;
            // generate a subset of data for this point cloud
            Vector3[] positions = new Vector3[numPointsPerCloud];
            float[] normalizedSignalStrength = new float[numPointsPerCloud];
            for (int j = 0; j < numPointsPerCloud; j++)
            {
                // normalzied signal strength stored in the 4th component of the vector
                normalizedSignalStrength[j] = data[offset + j].w * 0.3f;

                // position stored in the first 3 elements of the vector (conversion handled by implicit cast)
                positions[j] = data[offset + j];
            }

			// Create the point cloud using the subset of data
		
            GameObject obj = new GameObject("Empty");
            obj.transform.SetParent(transform, false);
            obj.AddComponent<PointCloud>().CreateMesh(positions, normalizedSignalStrength);
            obj.GetComponent<MeshRenderer>().material = pointCloudMaterial;
            pointClouds[i] = obj;
			Debug.Log("Object created");
		}

    }

	private void Update()
	{
		

	}

	public void OnDestroy()
	{
		
	}

}
