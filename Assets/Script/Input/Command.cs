using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    public ActionManager actionManager;

    public float poseDuration = .25f;
    private bool canBeControlled = true;

    public void MoveLeft()
    {
        if (canBeControlled)
        {
            actionManager.moveLeft.MoveAction();
            print("Move left.");
        }     
    }

    public void MoveRight()
    {
        if (canBeControlled)
        {
            actionManager.moveRight.MoveAction();
            print("Move right.");
        }
    }

    public void Jump()
    {
        if (canBeControlled)
        {
            actionManager.jump.JumpAction();
            print("Jump");
        }
    }

    public void MakePoseUp()
    {
        if (canBeControlled)
        {
            actionManager.poseUp.PoseAction();
            StopAllCoroutines();
            StartCoroutine(ResetPose());
            print("Pose up.");
        }
    }

    public void MakePoseDown()
    {
        if (canBeControlled)
        {
            actionManager.poseDown.PoseAction();
            StopAllCoroutines();
            StartCoroutine(ResetPose());
            print("Pose down.");
        }
    }

    public void MakePoseLeft()
    {
        if (canBeControlled)
        {
            actionManager.poseLeft.PoseAction();
            StopAllCoroutines();
            StartCoroutine(ResetPose());
            print("Pose left.");
        }
    }

    public void MakePoseRight()
    {
        if (canBeControlled)
        {
            actionManager.poseRight.PoseAction();
            StopAllCoroutines();
            StartCoroutine(ResetPose());
            print("Pose right.");
        }
    }

    public void DisableControl()
    {
        canBeControlled = false;
    }

    public void EnableControl()
    {
        canBeControlled = true;
    }

    private IEnumerator ResetPose()
    {
        yield return new WaitForSeconds(poseDuration);
        actionManager.runingPose.PoseAction();
    }
}
