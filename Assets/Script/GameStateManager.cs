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
            if (playerStatus.GetCurrentHealth() <= 0)
                PlayerDead();
        if (uiManager != null)
        {
            uiManager.score.text = "Score: " + playerStatus.GetPlayerScore().ToString();
            uiManager.combo.text = "Combo: " + playerStatus.GetPlayerCombo().ToString();
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
        Application.LoadLevel(Application.loadedLevel);
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
