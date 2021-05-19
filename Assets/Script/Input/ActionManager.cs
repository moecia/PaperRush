using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public Transform player;
    public PlayerStatus playerStatus;
    public SpriteRenderer playerSprite;
    public AudioSource playerAudio;
    public AudioManager audioManager;
    public SpriteManager spriteManager;

    public float jumpSpeed = 8.0f;
    public float distToGround = 1.1f;
    public Transform moveSpot_L, moveSpot_C, moveSpot_R;

    public Pose runingPose;
    public Pose poseUp;
    public Pose poseDown;
    public Pose poseLeft;
    public Pose poseRight;
    public Jump jump;
    public Move moveLeft;
    public Move moveRight;
    // Use this for initialization
    void Start()
    {
        InitializeActionsPool();
    }

    private void InitializeActionsPool()
    {
        runingPose = new Pose(PlayerStatus.PlayerPose.Running, playerStatus, playerSprite, playerAudio, audioManager.empty, spriteManager.running);
        poseUp = new Pose(PlayerStatus.PlayerPose.Up, playerStatus, playerSprite, playerAudio, audioManager.poseUp, spriteManager.poseUp);
        poseDown = new Pose(PlayerStatus.PlayerPose.Down, playerStatus, playerSprite, playerAudio, audioManager.poseDown, spriteManager.poseDown);
        poseLeft = new Pose(PlayerStatus.PlayerPose.Left, playerStatus, playerSprite, playerAudio, audioManager.poseLeft, spriteManager.poseLeft);
        poseRight = new Pose(PlayerStatus.PlayerPose.Right, playerStatus, playerSprite, playerAudio, audioManager.poseRight, spriteManager.poseRight);

        jump = new Jump(player, playerAudio, jumpSpeed, distToGround, audioManager.jump);

        moveLeft = new Move(Move.MoveDirection.Left, player, playerStatus, playerAudio, audioManager.move, moveSpot_L, moveSpot_C, moveSpot_R);
        moveRight = new Move(Move.MoveDirection.Right, player, playerStatus, playerAudio, audioManager.move, moveSpot_L, moveSpot_C, moveSpot_R);
    }
}

public class PlayerAction
{
    protected Transform player;
    protected PlayerStatus playerStatus;
    protected SpriteRenderer playerSprite;
    protected AudioSource playerAudio;
    protected AudioClip poseAudio;
    protected Sprite poseSprite;
}

public class Pose: PlayerAction
{
    PlayerStatus.PlayerPose pose;
    public Pose(PlayerStatus.PlayerPose pose, PlayerStatus playerStatus, SpriteRenderer playerSprite, AudioSource playerAudio, AudioClip poseAudio, Sprite poseSprite)
    {
        this.pose = pose;
        this.playerStatus = playerStatus;
        this.playerSprite = playerSprite;
        this.playerAudio = playerAudio;
        this.poseAudio = poseAudio;
        this.poseSprite = poseSprite;
    }

    public void PoseAction()
    {
        playerStatus.SetCurrentPose(pose);
        playerSprite.sprite = poseSprite;
        if (!playerAudio.isPlaying)
        {
            playerAudio.PlayOneShot(poseAudio);
        }
    }

    public Pose() { }
}

public class Jump : PlayerAction
{
    private float jumpSpeed;
    private float distToGround;
    private AudioClip jumpSound;

    public Jump(Transform player, AudioSource playerAudio,float jumpSpeed, float distToGround, AudioClip jumpSound)
    {
        this.player = player;
        this.playerAudio = playerAudio;
        this.jumpSpeed = jumpSpeed;
        this.distToGround = distToGround;
        this.jumpSound = jumpSound;
    }

    public Jump() { }

    public void JumpAction()
    {
        playerAudio.PlayOneShot(jumpSound);
        if (CheckIsGrounded())
        {
            player.GetComponent<Rigidbody>().velocity += new Vector3(0, jumpSpeed, 0);
        }
    }

    private bool CheckIsGrounded()
    {
        return Physics.Raycast(player.position, -Vector3.up, distToGround);
    }

}

public class Move: PlayerAction
{
    public enum MoveDirection
    {
        Left, Right
    }
    private MoveDirection moveDir;
    private AudioClip moveSound;
    private Transform moveSpot_L, moveSpot_C, moveSpot_R; 

    public Move(MoveDirection moveDir, Transform player, PlayerStatus playerStatus, AudioSource playerAudio, AudioClip moveSound, Transform moveSpot_L, Transform moveSpot_C, Transform moveSpot_R)
    {
        this.moveDir = moveDir;
        this.player = player;
        this.playerStatus = playerStatus;
        this.playerAudio = playerAudio;
        this.moveSound = moveSound;

        this.moveSpot_C = moveSpot_C;
        this.moveSpot_L = moveSpot_L;
        this.moveSpot_R = moveSpot_R;
    }

    public Move() { }

    public void MoveAction()
    {
        playerAudio.PlayOneShot(moveSound);
        if (moveDir == MoveDirection.Left)
        {
            if (player.localPosition.x == moveSpot_C.localPosition.x)
            {
                player.localPosition = new Vector2(moveSpot_L.localPosition.x, player.localPosition.y);
                playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Left);
            }

            else if (player.localPosition.x == moveSpot_R.localPosition.x)
            {
                player.localPosition = new Vector2(moveSpot_C.localPosition.x, player.localPosition.y);
                playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Center);
            }
        }

        else if (moveDir == MoveDirection.Right)
        {
            if (player.localPosition.x == moveSpot_C.localPosition.x)
            {
                player.localPosition = new Vector2(moveSpot_R.localPosition.x, player.localPosition.y);
                playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Right);
            }
            else if (player.localPosition.x == moveSpot_L.localPosition.x)
            {
                player.localPosition = new Vector2(moveSpot_C.localPosition.x, player.localPosition.y);
                playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Center);
            }
        }
    }
}