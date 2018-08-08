using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paperman : MonoBehaviour
{
    public Transform mainMover;
    public PlayerStatus playerStatus;
    public int healthDamage = -1;
    public int scoreRate = 1;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerStatus.GetCurrentHealth() > 0)
            mainMover.Translate(Vector3.forward * Time.deltaTime * playerStatus.GetCurrentSpeed());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            if (other.GetComponent<WallPlane>() != null)
            {
                WallPlane theWallObject = other.GetComponent<WallPlane>();
                switch (theWallObject.m_planeType)
                {
                    case WallPlane.m_Plane.Block:
                        playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.Running:
                        if (playerStatus.GetCurrentPose() == PlayerStatus.PlayerPose.Running)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseUp:
                        if (playerStatus.GetCurrentPose() == PlayerStatus.PlayerPose.Up)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseDown:
                        if (playerStatus.GetCurrentPose() == PlayerStatus.PlayerPose.Down)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseLeft:
                        if (playerStatus.GetCurrentPose() == PlayerStatus.PlayerPose.Left)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseRight:
                        if (playerStatus.GetCurrentPose() == PlayerStatus.PlayerPose.Right)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                }
            }
        }

        if (other.tag == "Jumpwall")
            playerStatus.SetCurrentHealth(healthDamage);
    }

}
