using UnityEngine;
using System.Collections;
using System.IO;

public class FileManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string path = Directory.GetCurrentDirectory () + "sdcard/media";

		Debug.Log ("PWD: " + path);


		DirectoryInfo dir = new DirectoryInfo(path);
		FileInfo[] info = dir.GetFiles("*.*");
		foreach (FileInfo f in info) 
		{
			Debug.Log(f.FullName);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
