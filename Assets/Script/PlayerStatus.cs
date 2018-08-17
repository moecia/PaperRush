using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameManager gameManager;
    public AnimatorManager animatorManager;
    public AudioManager audioManager;
    public AudioSource playerAudio;

    public float maxhealth = 3;
    public float currentHealth { get; private set; }

    public int speedUpIncrenment = 2;
    public float startMenuSpeed = 50.0f;
    public float initialSpeed = 10.0f;
    public float maxSpeed = 500.0f;

    public float currentSpeed { get; private set; }
    public Transform healthSlot;
    public GameObject healthPrefab;

    public bool godMode = false;

    public enum PlayerPose { Up, Down, Left, Right, Running };
    public PlayerPose currentPose { get; private set; }

    public enum PlayerSpot { Left, Center, Right };
    public PlayerSpot currentSpot { get; private set; }

    public int playerScore { get; private set; }
    public int scoreUpLimit = 999999;
    public int playerCombo { get; private set; }

    private void Start()
    {
        InitializePlayerStatus();
    }

    private void Update()
    {
        animatorManager.playerAnimator.speed = currentSpeed / 10;
    }

    private void InitializePlayerStatus()
    {
        currentPose = PlayerPose.Running;
        currentSpot = PlayerSpot.Center;
        playerScore = 0;
        playerCombo = 0;
        currentHealth = maxhealth;
        for (int i = 0; i < currentHealth; i++)
        {
            GameObject temp = Instantiate(healthPrefab, healthSlot.position, Quaternion.identity);
            temp.transform.SetParent(healthSlot);
            healthSlot.gameObject.SetActive(false);
        }
        if (gameManager.currentState == GameManager.GameState.StartMenu)
            currentSpeed = startMenuSpeed;
        else if (gameManager.currentState == GameManager.GameState.InProgress)
            currentSpeed = initialSpeed;
    }

    public void SetPlayerScore(int scoreChange)
    {
        ComboIncrement();
        playerAudio.PlayOneShot(audioManager.getScore);
        playerScore += scoreChange * 10 * (playerCombo + 1);
        SetCurrentSpeed(speedUpIncrenment);
        if (playerScore > scoreUpLimit)
            playerScore = scoreUpLimit;
    }

    private void ComboIncrement()
    {
        playerCombo += 1;
    }

    private void ResetCombo()
    {
        playerCombo = 0;
    }

    private void SetCurrentSpeed(float speedChange)
    {
        currentSpeed += speedChange;
        if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;
        else if (currentSpeed <= initialSpeed)
            currentSpeed = initialSpeed;
    }

    private void ResetSpeed()
    {
        currentSpeed = initialSpeed;
    } 

    public void SetCurrentHealth(float healthChange)
    {
        currentHealth += healthChange;
        if (healthChange < 0)
        {
            // Play sound
            playerAudio.PlayOneShot(audioManager.getHit);
            // Play effects.
            if (Camera.main.gameObject.GetComponent<CameraShake>() != null)
                StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());
            if (animatorManager != null)
                animatorManager.PlayBloodScreen();
            // Change data values.
            SetCurrentSpeed(-currentSpeed/2);
            ResetCombo();
            // Change health indicators looking.
            if (healthSlot.childCount != 0)
            {
                Destroy(healthSlot.GetChild(healthSlot.childCount - 1).gameObject);
                StartCoroutine(ShowCurrentHealth());
            }
        }
        if (currentHealth + healthChange > maxhealth)
            healthChange = maxhealth;
        else if (currentHealth + healthChange < 0)
            healthChange = 0;
    }

    private IEnumerator ShowCurrentHealth()
    {
        healthSlot.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        healthSlot.gameObject.SetActive(false);
    }

    public void SetCurrentPose(PlayerPose pose)
    {
        currentPose = pose;
    }

    public void SetPlayerSpot(PlayerSpot currentSpot)
    {
        this.currentSpot = currentSpot;
    }

    public void SlowdownToStartGame()
    {
        if (currentSpeed > initialSpeed)
            currentSpeed -= 10 * Time.deltaTime;
        else
            currentSpeed = initialSpeed;
    }
}
