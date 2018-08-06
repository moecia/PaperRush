using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    public ActionManager actionManager;
    public float poseDuration = 2.0f;

    public void MoveLeft()
    {
        actionManager.moveLeft.MoveAction();
        print("Move left.");
    }

    public void MoveRight()
    {
        actionManager.moveRight.MoveAction();
        print("Move right.");
    }

    public void Jump()
    {
        actionManager.jump.JumpAction();
        print("Jump");
    }

    public void MakePoseUp()
    {
        actionManager.poseUp.PoseAction();
        StopAllCoroutines();
        StartCoroutine(ResetPose());
        print("Pose up.");
    }

    public void MakePoseDown()
    {
        actionManager.poseDown.PoseAction();
        StopAllCoroutines();
        StartCoroutine(ResetPose());
        print("Pose down.");
    }

    public void MakePoseLeft()
    {
        actionManager.poseLeft.PoseAction();
        StopAllCoroutines();
        StartCoroutine(ResetPose());
        print("Pose left.");
    }

    public void MakePoseRight()
    {
        actionManager.poseRight.PoseAction();
        StopAllCoroutines();
        StartCoroutine(ResetPose());
        print("Pose right.");
    }

    private IEnumerator ResetPose()
    {
        yield return new WaitForSeconds(poseDuration);
        actionManager.runingPose.PoseAction();
    }
}
