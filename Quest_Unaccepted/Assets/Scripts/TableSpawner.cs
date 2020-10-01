using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpawner : MonoBehaviour {
    public GameObject[] tablesArray = new GameObject[4];
    public GameObject[] tablesPositions = new GameObject[3];

	public void Start () {
		for (int i = 0; i < tablesPositions.Length; i++)
        {
            Instantiate(tablesArray[Random.Range(0, tablesArray.Length)], tablesPositions[i].transform.position, tablesPositions[i].transform.rotation);
        }
	}
}
