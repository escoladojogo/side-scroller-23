using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour
{
    public Text name1;
    public Text score1;
    public Text name2;
    public Text score2;
    public Text name3;
    public Text score3;

    int[] scores;
    string[] names = new string[3];

    void InitializeScores()
    {
        scores = new int[3];
        string level = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey(level + "score0"))
        {
            for (int i = 0; i < 3; i++)
            {
                scores[i] = PlayerPrefs.GetInt(level + "score" + i);
                names[i] = PlayerPrefs.GetString(level + "name" + i);
            }

            score1.text = scores[0].ToString();
            score2.text = scores[1].ToString();
            score3.text = scores[2].ToString();
            name1.text = names[0];
            name2.text = names[1];
            name3.text = names[2];
        }
        else
        {
            int score = 30;

            for (int i = 0; i < 3; i++)
            {
                scores[i] = score;
                score = score - 10;
            }

            names[0] = name1.text;
            names[1] = name2.text;
            names[2] = name3.text;
        }
    }

    public bool IsHighscore(int score)
    {
        if (scores == null)
        {
            InitializeScores();
        }

        if (score > scores[scores.Length - 1])
        {
            return true;
        }
        return false;
    }

    public void AddScore(string name, int score)
    {
        for (int i = scores.Length - 1; i >= 0; i--)
        {
            if (i > 0 && scores[i - 1] < score)
            {
                scores[i] = scores[i - 1];
                names[i] = names[i - 1];
            }
            else
            {
                scores[i] = score;
                names[i] = name;
                break;
            }
        }

        score1.text = scores[0].ToString();
        name1.text = names[0];

        score2.text = scores[1].ToString();
        name2.text = names[1];

        score3.text = scores[2].ToString();
        name3.text = names[2];

        SaveLeaderboard();
    }

    void SaveLeaderboard()
    {
        string level = SceneManager.GetActiveScene().name;

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt(level + "score" + i, scores[i]);
            PlayerPrefs.SetString(level + "name" + i, names[i]);
        }

        PlayerPrefs.Save();
    }
}
