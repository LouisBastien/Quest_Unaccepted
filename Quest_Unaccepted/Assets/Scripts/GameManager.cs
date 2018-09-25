    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int score;
    static public GameManager Instance;
    public static bool onPause = true;
    public GameObject pause;
    public Text ScoreText;

    private bool canAddScore = true;

    void Awake()
    {
        Instance = this;
    }

    void Start () {
        CsvManager csvManager = new CsvManager();
        csvManager.Init();
        csvManager.readFromFile();
	}
	
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (onPause == false)
                pauseGame();
            else
                resumeGame();
            onPause = !onPause;
        }
        if (!onPause)
        {
            if (canAddScore)
            {
                StartCoroutine(WaitAndAddScore(3f, 1));
                canAddScore = false;
            }
        }
        ScoreText.text = "Score : " + score;
	}

    public void OnDefeat()
    {
        onPause = true;
        PlayerPrefs.SetInt("ActualScore", score);
        SceneManager.LoadScene("HighScores");
    }

    private void addScore(int bonusScore)
    {
        score += bonusScore;
    }

    private void pauseGame()
    {
        pause.SetActive(true);
    }

    private void resumeGame()
    {
        pause.SetActive(false);
    }

    private IEnumerator WaitAndAddScore(float waitTime, int scoreToAdd)
    {
        yield return new WaitForSeconds(waitTime);
        score += scoreToAdd;
        canAddScore = true;
    }
}
