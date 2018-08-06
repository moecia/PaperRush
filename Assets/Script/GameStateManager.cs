using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public UIManager uiManager;
    public PlayerStatus playerStatus;

	void Start ()
    {
		
	}

    public void PlayerDead()
    {
        print("You are dead.");
    }
}
