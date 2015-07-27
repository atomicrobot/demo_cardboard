using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeMatrix : MonoBehaviour {
	
	public GameObject cubePrefab;
	public float Multiplier = 200;
	public int bins = 25;
	public AudioSource AS;

	List<List<GameObject>> matrix;
	
	// Use this for initialization
	void Start () {
		//Audio source will begin playing automatically
		//Vector3 pos = new Vector3(0,0,-bins*0.75f - 1);
		//transform.position = pos;
		
		matrix = new List<List<GameObject>> ();
		for (int i=0; i<bins*2; i++) {
			List<GameObject> row = new List<GameObject>();
			for (int j=0;j<bins*2;j++){
				GameObject temp = Instantiate(cubePrefab, new Vector3(i*2+0.5f-bins*2,0.0f,j*2 + 0.5f - bins*2),Quaternion.identity) as GameObject;
				//temp.transform.parent = transform;
				row.Add(temp);
			}
			matrix.Add(row);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		int num = 128;
		float[] spectrum = AS.GetSpectrumData(num, 0, FFTWindow.Blackman);
		int i = 0;
		
		int lastBinIndex = (bins * 2) - 1;
		
		while (i<bins){
			float value = spectrum[i] * Multiplier;
			for (int j=0;j<bins*2;j++){
				
				Vector3 scale = matrix[i][j].transform.localScale;
				scale.y = value;
				matrix[i][j].transform.localScale = scale;
				matrix[i][j].transform.position = new Vector3(matrix[i][j].transform.position.x, matrix[i][j].transform.localScale.y/2, matrix[i][j].transform.position.z);
				
				scale = matrix[j][i].transform.localScale;
				scale.y = value;
				matrix[j][i].transform.localScale = scale;
				matrix[j][i].transform.position = new Vector3(matrix[j][i].transform.position.x, matrix[j][i].transform.localScale.y/2, matrix[j][i].transform.position.z);
				
				scale = matrix[j][lastBinIndex-i].transform.localScale;
				scale.y = value;
				matrix[j][lastBinIndex-i].transform.localScale = scale;
				matrix[j][lastBinIndex-i].transform.position = new Vector3(matrix[j][lastBinIndex-i].transform.position.x, matrix[j][lastBinIndex-i].transform.localScale.y/2, matrix[j][lastBinIndex-i].transform.position.z);
				
				scale = matrix[lastBinIndex-i][j].transform.localScale;
				scale.y = value;
				matrix[lastBinIndex-i][j].transform.localScale = scale;
				matrix[lastBinIndex-i][j].transform.position = new Vector3(matrix[lastBinIndex-i][j].transform.position.x, matrix[lastBinIndex-i][j].transform.localScale.y/2, matrix[lastBinIndex-i][j].transform.position.z);
			}
			
			
			i++;
		}
	}
}