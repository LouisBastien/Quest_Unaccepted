using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighManager : MonoBehaviour {
    private readonly string[] names = new string[5];
    private readonly int[] scores = new int[5];
    private int actualScore;

    public Text[] nameTexts = new Text[5];
    public Text[] scoreTexts = new Text[5];
    public Text actualScoreText;

    private string actualNameText;

    public InputField playerName;
    private InputField.SubmitEvent se;

    public void Start () {
        for (int i = 0; i < names.Length; i++)
        {
            nameTexts[i].text = names[i] = PlayerPrefs.GetString("HighScoreName" + (i + 1));
            scores[i] = PlayerPrefs.GetInt("HighScoreScore" + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetInt("HighScoreScore" + (i + 1)).ToString();
        }
       actualScore = PlayerPrefs.GetInt("ActualScore");

        actualScoreText.text = "Score : " + actualScore;

        se = new InputField.SubmitEvent();
        se.AddListener(InputListener);
        playerName.onEndEdit = se;
    }

    private void InputListener(string arg)
    {
        actualNameText = arg;
    }

    public void UpdateHighScores()
    {
        CsvManager csvManager = new CsvManager();

        int scoreTmp;
        string nameTmp;

        for (int i = 0; i < scores.Length; i++)
        {
            if (actualScore >= scores[i])
            {
                scoreTmp = scores[i];
                nameTmp = names[i];
                scores[i] = actualScore;
                names[i] = actualNameText;
                actualScore = scoreTmp;
                actualNameText = nameTmp;
            }
        }
        for (int j = 0; j < names.Length; j++)
        {
            PlayerPrefs.SetString("HighScoreName" + (j + 1), names[j]);
            PlayerPrefs.SetInt("HighScoreScore" + (j + 1), scores[j]);
        }
        csvManager.WriteInFile(names, scores);
    }

}
