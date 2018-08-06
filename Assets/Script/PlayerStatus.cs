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

    public Pose runingPose;
    public Pose poseUp;
    public Pose poseDown;
    public Pose poseLeft;
    public Pose poseRight;
    private Pose currentPose;

    public enum PlayerSpot { Left, Center, Right };
    private PlayerSpot currentSpot = PlayerSpot.Center;

    public AudioManager audioManager;
    public SpriteManager spriteManager;

    private void Start()
    {
        currentHealth = maxhealth;
        currentSpeed = initialSpeed;

        runingPose = new Pose(Pose.PlayerPose.Runing, new AudioClip(), spriteManager.running);
        poseUp = new Pose(Pose.PlayerPose.Runing, audioManager.poseUp, spriteManager.poseUp);
        poseDown = new Pose(Pose.PlayerPose.Runing, audioManager.poseDown, spriteManager.poseDown);
        poseLeft = new Pose(Pose.PlayerPose.Runing, audioManager.poseLeft, spriteManager.poseLeft);
        poseRight = new Pose(Pose.PlayerPose.Runing, audioManager.poseRight, spriteManager.poseRight);

        currentPose = new Pose();
        currentPose = runingPose;

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

    private void OnTriggerEnter(Collider other)
    {
        if(!godMode)
        {
            if (other.CompareTag("wall"))
            {

            }
        }
    }
}

public class Pose
{
    public enum PlayerPose
    {
        Runing,
        Yoga_Up,
        Mickeal_Right,
        WiiFit_Left,
        SpiltFoot_Down
    }
    private PlayerPose currentPose { get; set; }
    public AudioClip poseAudio { get; set; }
    public Sprite poseSprite { get; set; }

    public Pose(PlayerPose playerPose, AudioClip poseAudio, Sprite poseSprite)
    {
        this.currentPose = currentPose;
        this.poseAudio = poseAudio;
        this.poseSprite = poseSprite;
    }

    public Pose() {}
}
