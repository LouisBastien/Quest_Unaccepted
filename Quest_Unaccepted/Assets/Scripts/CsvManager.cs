using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvManager : MonoBehaviour {

    private string path;

    public void Init()
    {
        path = getPath();
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
    }

    public void readFromFile()
    {
        string name;
        string score;
        int intScore;

        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(","[0]);
            name = parts[0];
            score = parts[1];
            int.TryParse(score, out intScore);
            PlayerPrefs.SetString("HighScoreName" + (i + 1), name);
            PlayerPrefs.SetInt("HighScoreScore" + (i + 1), intScore);
        }
    }

    public void WriteInFile(string[] names, int[] scores)
    {
        path = getPath();
        string[] lines = new string[5];

        for (int i = 0; i < 5; i++)
        {
            lines[i] = names[i] + "," + scores[i];
        }
        File.WriteAllLines(path, lines);
    }

    private string getPath()
    {
        #if UNITY_EDITOR
        return Application.dataPath + "/" + "highscores.csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+"highscores.csv";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"highscores.csv";
        #else
        return Application.dataPath +"/"+"highscores.csv";
        #endif
    }
        
}
