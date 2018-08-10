using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{   
    public static bool SetHighestScore(int score)
    {
        if (score > GetHighestScore())
        {
            PlayerPrefs.SetInt("highestScore", score);
            return true;
        }
        else
            return false;
    }

    public static int GetHighestScore()
    {
        return PlayerPrefs.GetInt("highestScore");
    }

    public static void SetHighestCombo(int combo)
    {
        PlayerPrefs.SetInt("highestCombo", combo);
    }

    public static int GetHighestCombo()
    {
        return PlayerPrefs.GetInt("highestCombo");
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
