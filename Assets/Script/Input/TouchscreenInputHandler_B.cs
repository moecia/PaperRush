using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class TouchscreenInputHandler_B : MonoBehaviour {

    public Command command;

    [Header("Touchscreen Inputs")]
    [Tooltip("Controls how the swipe gesture ends. See SwipeGestureRecognizerSwipeMode enum for more details.")]
    public SwipeGestureRecognizerEndMode swipeMode = SwipeGestureRecognizerEndMode.EndImmediately;
    public float minimumNumberOfTouchesToTrack = .25f;

    // Use this for initialization
    void Start()
    {
        command = transform.GetComponent<Command>();
        SwipeGestureRecognizer swipeMovement = new SwipeGestureRecognizer();
        swipeMovement.MinimumDistanceUnits = minimumNumberOfTouchesToTrack;
        swipeMovement.MinimumNumberOfTouchesToTrack = 1;
        //swipeMovement.DirectionThreshold = 0;
        swipeMovement.EndMode = swipeMode;
        FingersScript.Instance.AddGesture(swipeMovement);
        swipeMovement.StateUpdated += SwipeUpdated;

        //SwipeGestureRecognizer swipePose = new SwipeGestureRecognizer();
        //swipePose.MinimumNumberOfTouchesToTrack = 1;
        //swipePose.DirectionThreshold = 0;
        //swipeMovement.EndMode = swipeMode;
        //FingersScript.Instance.AddGesture(swipePose);
        //swipePose.StateUpdated += SwipeUpdated;

    }

    void SwipeUpdated(DigitalRubyShared.GestureRecognizer gesture)
    {
        SwipeGestureRecognizer swipe = gesture as SwipeGestureRecognizer;
        if (swipe.State == GestureRecognizerState.Ended)
        {
            if (swipe.FocusX < Screen.width / 2)
            {
                if (swipe.EndDirection == SwipeGestureRecognizerDirection.Up)
                    command.Jump();
                else if (swipe.EndDirection == SwipeGestureRecognizerDirection.Left)
                    command.MoveLeft();
                else if (swipe.EndDirection == SwipeGestureRecognizerDirection.Right)
                    command.MoveRight();
            }

            if (swipe.FocusX > Screen.width / 2)
            {
                if (swipe.EndDirection == SwipeGestureRecognizerDirection.Up)
                    command.MakePoseUp();
                else if (swipe.EndDirection == SwipeGestureRecognizerDirection.Down)
                    command.MakePoseDown();
                else if (swipe.EndDirection == SwipeGestureRecognizerDirection.Left)
                    command.MakePoseLeft();
                else if (swipe.EndDirection == SwipeGestureRecognizerDirection.Right)
                    command.MakePoseRight();
            }
        }
    }
}
