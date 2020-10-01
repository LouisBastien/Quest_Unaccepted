using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject scoreManager;

    public void LoadScene(string scene)
    {
        scoreManager.SendMessage("UpdateHighScores");
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        scoreManager.SendMessage("UpdateHighScores");
        Application.Quit();
    }
}
