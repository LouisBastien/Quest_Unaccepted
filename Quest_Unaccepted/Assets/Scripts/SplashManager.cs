using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("MainScene");
        else if (Input.GetKey(KeyCode.Space))
            SceneManager.LoadScene("MainScene");
    }
}
