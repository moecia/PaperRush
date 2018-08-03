using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class PlayerMovement : MonoBehaviour {
    public enum m_playerSpot
    {
        Left,
        Center,
        Right
    }
    [SerializeField] private m_playerSpot playerSpot;
    private PlayerMover m_playerMover = null;
    private int m_health = 100;
    private int spotID = 1;
    [SerializeField] private Transform[] m_sideMove;

    private void Start()
    {
        m_playerMover = this.GetComponent<PlayerMover>();
    }
    public void Update()
    {
        MoveLeftRight();
    }
    public void MoveLeftRight()
    {
        switch (playerSpot)
        {
            case m_playerSpot.Center:
                if (Input.GetKeyDown("a"))
                {
                    playerSpot = m_playerSpot.Left;
                    m_playerMover.MoveToPosition(m_sideMove[spotID].transform.position);
                    spotID = 0;
                }
                if (Input.GetKeyDown("d"))
                {
                    playerSpot = m_playerSpot.Right;
                    spotID = 2;
                }
                break;
            case m_playerSpot.Left:
                if (Input.GetKeyDown("d"))
                {
                    playerSpot = m_playerSpot.Center;
                    spotID = 1;
                }
                break;
            case m_playerSpot.Right:
                if (Input.GetKeyDown("a"))
                {
                    playerSpot = m_playerSpot.Center;
                    spotID = 1;
                }
                break;
        }
        float dist = Mathf.Abs(m_sideMove[spotID].transform.position.x - this.transform.position.x);
        if (dist > 0.3f)
        {
            m_playerMover.MoveToPosition(m_sideMove[spotID].transform.position);
        }
    }
}
