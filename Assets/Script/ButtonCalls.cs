using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handling Button calls.
/// </summary>
public class ButtonCalls : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject inGamePanel;
    public GameObject startGamePanel;

    public void StartGame()
    {
        gameManager.currentState = GameManager.GameState.InProgress;
        inGamePanel.SetActive(true);
        startGamePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ToggleTutorial()
    {
        GameData.SetTutorialVisibility(!GameData.GetTutorialVisibility());
    }


}
