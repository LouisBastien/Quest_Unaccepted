using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {

	public void Update ()
    {
        if (Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("MainScene");
        else if (Input.GetKey(KeyCode.Space))
            SceneManager.LoadScene("MainScene");
    }
}
