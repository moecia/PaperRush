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

    private Pose currentPose;
    public enum PlayerSpot { Left, Center, Right };
    private PlayerSpot currentSpot = PlayerSpot.Center;

    private void Start()
    {
        currentHealth = maxhealth;
        currentSpeed = initialSpeed;

        currentPose = new Pose();

    }

    public void SetPlayerSpot(PlayerSpot currentSpot)
    {
        this.currentSpot = currentSpot;
    }

    public void SetCurrentPose(Pose pose)
    {
        currentPose = pose;
    }

    public Pose GetCurrentPose()
    {
        return currentPose;
    }
}
