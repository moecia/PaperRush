using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxhealth = 3;
    private float currentHealth;

    public float initialSpeed = 1.0f;
    public float maxSpeed = 100.0f;
    private float currentSpeed;

    [SerializeField]
    private bool godMode = false;

    public GameStateManager gsm;

    public enum PlayerPose { Up, Down, Left, Right, Running };
    private PlayerPose currentPose = PlayerPose.Running;

    public enum PlayerSpot { Left, Center, Right };
    private PlayerSpot currentSpot = PlayerSpot.Center;

    private int playerScore = 0;
    public int scoreUpLimit = 999999;
    private int playerCombo = 0;

    private void Start()
    {
        currentHealth = maxhealth;
        currentSpeed = initialSpeed;

    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void SetPlayerScore(int scoreChange)
    {
        playerScore += scoreChange;
        ComboIncrement();
        if (playerScore > scoreUpLimit)
            playerScore = scoreUpLimit;
    }

    public int GetPlayerCombo()
    {
        return playerCombo;
    }

    private void ComboIncrement()
    {
        playerCombo += 1;
    }

    private void ResetCombo()
    {
        playerCombo = 0;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SetCurrentSpeed(float speedChange)
    {
        currentSpeed += speedChange;
        if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;
        else if (currentSpeed <= 0)
            currentSpeed = initialSpeed;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(float healthChange)
    {
        currentHealth += healthChange;
        ResetCombo();
        if (currentHealth + healthChange > maxhealth)
            healthChange = maxhealth;
        else if (currentHealth + healthChange < 0)
            gsm.PlayerDead();
    }

    public PlayerPose GetCurrentPose()
    {
        return currentPose;
    }

    public void SetCurrentPose(PlayerPose pose)
    {
        currentPose = pose;
    }

    public PlayerSpot GetCurrentSpot()
    {
        return currentSpot;
    }

    public void SetPlayerSpot(PlayerSpot currentSpot)
    {
        this.currentSpot = currentSpot;
    }
}
