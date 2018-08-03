using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using System.Collections;
//using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour {

    [SerializeField] private Text m_speedText = null;

    [SerializeField] private float m_startMoveSpeed = 10f;
    [SerializeField] private float m_currentMoveSpeed = 10f;
    [SerializeField] private float m_maxMoveSpeed = 60f;
    private bool m_isAlive = false;
    public bool isAlive
    { get { return m_isAlive; } }
    [SerializeField]private Vector3 m_velocity = Vector3.zero;
    private Rigidbody m_rigidbody;

    private void Reset()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();

    }
    private void Start()
    {
        m_isAlive = true;
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_speedText = GameObject.FindWithTag("SpeedUI").GetComponent<Text>();
        m_speedText.text = ("Speed: " + m_currentMoveSpeed + "km ／h");

    }
    private void Update()
    {
        if (m_isAlive)
        {
            Moving();
        }
    }
    private void Moving()
    {
        //m_velocity.z = m_currentMoveSpeed;
        this.transform.Translate(Vector3.forward * Time.deltaTime * m_currentMoveSpeed);
        //m_rigidbody.velocity = m_velocity;
    }
    public void SpeedUp()
    {
        if (m_currentMoveSpeed < m_maxMoveSpeed)
        { m_currentMoveSpeed += 2f;}
        m_speedText.text = ("Speed: " + m_currentMoveSpeed + "km ／h");
    }
    public void ResetSpeed()
    {
        m_currentMoveSpeed = m_startMoveSpeed;
        m_speedText.text = ("Speed: " + m_currentMoveSpeed + "km ／h");
    }
}
