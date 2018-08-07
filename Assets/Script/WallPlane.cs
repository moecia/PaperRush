using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlane : MonoBehaviour {

    public enum m_Plane
    {
        Block,
        Running,
        PoseUp, //Up
        PoseRight, //Right
        PoseLeft, // Left
        PoseDown // Down
    }
    public m_Plane m_planeType = m_Plane.Block;
    private void Awake()
    {
        m_planeType = m_Plane.Block;
    }
    public void SetWall()
    {
        m_planeType = m_Plane.Block;
        RandomPickPose();
    }

    private void RandomPickPose()
    {
        m_planeType = (m_Plane)Random.Range(0, System.Enum.GetValues(typeof(m_Plane)).Length);
        if(m_planeType == m_Plane.Block)
        {
            m_planeType = m_Plane.Running;
        }
        if (m_planeType == m_Plane.Running)
        {
            this.GetComponent<Renderer>().material.mainTexture = (Resources.Load("Pose_Run_Wall") as Texture);
        }
        if (m_planeType == m_Plane.PoseUp)
        {
            this.GetComponent<Renderer>().material.mainTexture = (Resources.Load("Pose_Up_Wall") as Texture);
        }
        if (m_planeType == m_Plane.PoseDown)
        {
            this.GetComponent<Renderer>().material.mainTexture = (Resources.Load("Pose_Low_Wall") as Texture);
        }
        if (m_planeType == m_Plane.PoseRight)
        {
            this.GetComponent<Renderer>().material.mainTexture = (Resources.Load("Pose_Right_Wall") as Texture);
        }
        if (m_planeType == m_Plane.PoseLeft)
        {
            this.GetComponent<Renderer>().material.mainTexture = (Resources.Load("Pose_Left_Wall") as Texture);
        }
    }
}
