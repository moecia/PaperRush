using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(Rigidbody))]
public class Command : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public AudioSource playerAudio;
    private PlayerStatus playerStatus;    
    [SerializeField]
    private float jumpSpeed = 8.0f;
    public Transform moveSpot_L, moveSpot_C, moveSpot_R;
    public float distToGround = 1.1f;
    public float poseDuration = 2.0f;

    private void Start()
    {
        playerStatus = transform.GetComponent<PlayerStatus>();
    }

    public void MoveLeft()
    {
        if (transform.position == moveSpot_C.position)
        {
            transform.position = moveSpot_L.position;
            playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Left);
        }
        else if (transform.position == moveSpot_R.position)
        {
            transform.position = moveSpot_C.position;
            playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Center);
        }
        print("Move left.");
    }

    public void MoveRight()
    {
        if (playerStatus.transform.position == moveSpot_C.position)
        {
            transform.position = moveSpot_R.position;
            playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Right);
        }
        else if (playerStatus.transform.position == moveSpot_L.position)
        {
            playerStatus.transform.position = moveSpot_C.position;
            playerStatus.SetPlayerSpot(PlayerStatus.PlayerSpot.Center);
        }
        print("Move right.");
    }

    public void Jump()
    {
        if (CheckIsGrounded())
        {
            transform.GetComponent<Rigidbody>().velocity += new Vector3(0, jumpSpeed, 0);
            print("Jump");
        }
    }

    public void MakePoseUp()
    {
        playerStatus.SetCurrentPose(playerStatus.poseUp);
        StopAllCoroutines();
        StartCoroutine(DoingPose());
        print("Pose up.");
    }

    public void MakePoseDown()
    {
        playerStatus.SetCurrentPose(playerStatus.poseDown);
        StopAllCoroutines();
        StartCoroutine(DoingPose());
        print("Pose down.");
    }

    public void MakePoseLeft()
    {
        playerStatus.SetCurrentPose(playerStatus.poseLeft);
        StopAllCoroutines();
        StartCoroutine(DoingPose());
        print("Pose left.");
    }

    public void MakePoseRight()
    {
        playerStatus.SetCurrentPose(playerStatus.poseRight);
        StopAllCoroutines();
        StartCoroutine(DoingPose());
        print("Pose right.");
    }

    private IEnumerator DoingPose()
    {
        playerAudio.PlayOneShot(playerStatus.GetCurrentPose().poseAudio);
        playerSprite.sprite = playerStatus.GetCurrentPose().poseSprite;
        yield return new WaitForSeconds(poseDuration);
        playerStatus.SetCurrentPose(playerStatus.runingPose);
        playerSprite.sprite = playerStatus.GetCurrentPose().poseSprite;
    }

    private bool CheckIsGrounded()
    {
        return Physics.Raycast(this.transform.position, -Vector3.up, distToGround);
    }
}
