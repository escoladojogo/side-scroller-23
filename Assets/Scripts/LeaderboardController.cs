using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public Text name1;
    public Text score1;
    public Text name2;
    public Text score2;
    public Text name3;
    public Text score3;

    int scorePos1 = 30;
    int scorePos2 = 20;
    int scorePos3 = 10;

    public bool IsHighscore(int score)
    {
        if (score > scorePos3)
        {
            return true;
        }
        return false;
    }

    public void AddScore(string name, int score)
    {
        if (score > scorePos1)
        {
            name3.text = name2.text;
            score3.text = score2.text;
            name2.text = name1.text;
            score2.text = score1.text;
            name1.text = name;
            score1.text = score.ToString();
        }
        else if (score > scorePos2)
        {
            name3.text = name2.text;
            score3.text = score2.text;
            name2.text = name;
            score2.text = score.ToString();
        }
        else if (score > scorePos3)
        {
            name3.text = name;
            score3.text = score.ToString();
        }
    }
}
