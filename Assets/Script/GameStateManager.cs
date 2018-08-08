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
        if (playerStatus.GetCurrentHealth() <= 0)
            PlayerDead();
        uiManager.health.text = "Health: "  + playerStatus.GetCurrentHealth().ToString();
        uiManager.score.text = "Score: " + playerStatus.GetPlayerScore().ToString();
        uiManager.combo.text = "Combo: " + playerStatus.GetPlayerCombo().ToString();
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
}
