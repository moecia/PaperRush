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

    public static void InitializeTutorialVisibility()
    {
        if (!PlayerPrefs.HasKey("TutorialVisibility"))
            GameData.SetTutorialVisibility(true);
    }

    public static void SetTutorialVisibility(bool flag)
    {
        PlayerPrefsX.SetBool("TutorialVisibility", flag);
    }

    public static bool GetTutorialVisibility()
    {
        return PlayerPrefsX.GetBool("TutorialVisibility");
    }

    public static void InitializeLocalization()
    {
        if(!PlayerPrefs.HasKey("Localization"))
            PlayerPrefs.SetInt("Localization", 0);
    }

    public static void SetLocalization(int locIndex)
    {
        // 0: English, 1: SCN, 2: TCN
        PlayerPrefs.SetInt("Localization", locIndex);
    }

    public static int GetLocalization()
    {
        return PlayerPrefs.GetInt("Localization");
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
