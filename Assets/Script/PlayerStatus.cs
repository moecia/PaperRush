using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public readonly float initialSpeed = 1.0f;
    public readonly float maxSpeed = 100.0f;
    private float currentSpeed;

    public enum PlayerPose
    {
        Runing,
        Yoga_Up,
        Mickeal_Right,
        WiiFit_Left,
        SpiltFoot_Down
    }
    public PlayerPose currentPose = PlayerPose.Runing;

    public bool isGrounded { get { return isGrounded;} }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    
}
