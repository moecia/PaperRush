using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(Rigidbody))]
public class InputHandler : MonoBehaviour
{
    private PlayerStatus playerStatus;
    [SerializeField]
    private float jumpSpeed = 8.0f;

    private void Start()
    {
        playerStatus = transform.GetComponent<PlayerStatus>();
    }

    public void MoveLeft()
    {

    }

    public void MoveRight()
    {
    }

    public void Jump()
    {
        if (playerStatus.isGrounded)
        {

        }
    }

    public void MakePoseLeft()
    {
        playerStatus.currentPose = PlayerStatus.PlayerPose.WiiFit_Left;
    }

    public void MakePoseRight()
    {
        playerStatus.currentPose = PlayerStatus.PlayerPose.Mickeal_Right;
    }

    public void MakePoseUp()
    {
        playerStatus.currentPose = PlayerStatus.PlayerPose.Yoga_Up;
    }

    public void MakePoseDown()
    {
        playerStatus.currentPose = PlayerStatus.PlayerPose.SpiltFoot_Down;
    }
}
