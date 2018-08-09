using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    public UIManager uiManager;
    public PlayerStatus playerStatus;

	void Start ()
    {
	}

    void Update()
    {
        if(playerStatus != null)
            if (playerStatus.currentHealth <= 0)
                PlayerDead();
        if (uiManager != null)
        {
            uiManager.score.text = "Score: " + playerStatus.playerScore.ToString();
            uiManager.combo.text = "Combo: " + playerStatus.playerCombo.ToString();
        }
    }


    public void PlayerDead()
    {
        print("You are dead.");
        uiManager.gameOverPanel.SetActive(true);
        enabled = false;
    }

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
