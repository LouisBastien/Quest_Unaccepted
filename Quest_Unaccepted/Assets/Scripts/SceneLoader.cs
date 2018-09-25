using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject scoreManager;

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        scoreManager.SendMessage("UpdateHighScores");
    }

    public void QuitGame()
    {
        Application.Quit();
        scoreManager.SendMessage("UpdateHighScores");
    }
}
