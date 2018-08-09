using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite running;
    public Sprite poseUp;
    public Sprite poseDown;
    public Sprite poseLeft;
    public Sprite poseRight;
    void Start ()
    {
        running = Resources.Load<Sprite>("Pose_Run");
        poseUp = Resources.Load<Sprite>("Pose_Up");
        poseDown = Resources.Load<Sprite>("Pose_Low");
        poseLeft = Resources.Load<Sprite>("Pose_Left");
        poseRight = Resources.Load<Sprite>("Pose_Right");
    }
}
