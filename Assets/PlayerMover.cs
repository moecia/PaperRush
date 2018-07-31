using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    [SerializeField] private AudioSource m_audio = null;
    [SerializeField] private float m_startSpeed = 30f;
    [SerializeField] private float m_currentSpeed = 30f;
    [SerializeField] private float m_maxSpeed = 60f;
    [SerializeField] private float m_jumpSpeed = 8f;
    private Vector3 m_velocity = Vector3.zero;
    private Rigidbody m_playerRigidbody;
    private bool m_isMoving = true;
    private float m_distoGround = 0.5f;

    private bool m_isChangingGravity = true;
    public bool isChangingGravity
    { get { return m_isChangingGravity; } }
    public Vector3 m_gravity;

    private bool isGrounded = false;
    public bool m_isGrounded
    { get { return isGrounded; } }
    //private bool isJumping = false;

    // Use this for initialization
    private void Start ()
    {
        m_audio = this.GetComponent<AudioSource>();
        m_gravity = Physics.gravity;
        m_playerRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update ()
    {
        if(m_isChangingGravity)
        {
            changeGravity();
            Jump();
        }
    }
    public void MoveToPosition(Vector3 goal)
    {
        Vector3 newgoal = this.transform.position;
        newgoal.x = goal.x;
        //if (!isJumping)
        //{
            float speed = m_currentSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, newgoal, speed);
        //}
    }
    public bool PlayerIsGrounded()
    {
        return Physics.Raycast(this.transform.position, -Vector3.up, m_distoGround + 0.6f);
    }
    public void changeGravity()
    {
        Physics.gravity = m_gravity;
        //m_gravity = -gameObject.transform.parent.transform.up * 12;
    }
    public void Jump()
    {
        isGrounded = PlayerIsGrounded();
        m_velocity.y = m_playerRigidbody.velocity.y;

        if (isGrounded)
        {
            //isJumping = false; 
            if (Input.GetButtonDown("Jump"))
            {
                m_audio.PlayOneShot((Resources.Load<AudioClip>("JumpSound")), 1);
                m_velocity.y = m_jumpSpeed;
                print("jump");
                //isJumping = true;
            }
        }
        m_playerRigidbody.velocity = m_velocity;

    }

}
