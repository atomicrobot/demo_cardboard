using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpinningTower : MonoBehaviour {

	public GameObject cubePrefab;
	public float Multiplier = 0.5f;
	public int bins = 25;
	public AudioSource AS;
	public bool Clockwise = true;

	List<GameObject> matrix;

	// Use this for initialization
	void Start () {
		matrix = new List<GameObject> ();
		for (int i=0; i<bins; i++) {
			GameObject temp = Instantiate(cubePrefab, new Vector3(transform.position.x,transform.position.y + i*2,transform.position.z),Quaternion.identity) as GameObject;
			temp.transform.parent = transform;
			temp.transform.localScale = new Vector3(100,100,100);
			matrix.Add(temp);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int num = 128;
		float[] spectrum = AS.GetSpectrumData(num, 0, FFTWindow.Blackman);
		int i = 0;
		
		int lastBinIndex = (bins) - 1;
		
		while (i<bins){
			float value = spectrum[i] * Multiplier;
			if (!Clockwise)
				matrix[i].transform.Rotate(new Vector3(0,-value,0));
			else
				matrix[i].transform.Rotate(new Vector3(0,value,0));
			
			i++;
		}

	}
}
