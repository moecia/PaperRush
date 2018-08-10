using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void BackToMenu()
    {
        print("Under construction...");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
