using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class TouchscreenInputHandler_A : MonoBehaviour {

    public Command command;

    [Header("Touchscreen Inputs")]
    [Tooltip("Controls how the swipe gesture ends. See SwipeGestureRecognizerSwipeMode enum for more details.")]
    public SwipeGestureRecognizerEndMode swipeMode = SwipeGestureRecognizerEndMode.EndImmediately;

    // Use this for initialization
    void Start ()
    {
        command = transform.GetComponent<Command>();

        SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
        swipe.MinimumNumberOfTouchesToTrack = 1;
        swipe.DirectionThreshold = 0;
        swipe.EndMode = swipeMode;
        FingersScript.Instance.AddGesture(swipe);
        swipe.StateUpdated += SwipeUpdated;

        TapGestureRecognizer twoFingerTap = new TapGestureRecognizer();
        twoFingerTap.MinimumNumberOfTouchesToTrack = twoFingerTap.MaximumNumberOfTouchesToTrack = 2;
        FingersScript.Instance.AddGesture(twoFingerTap);
        twoFingerTap.StateUpdated += TapUpdated;
    }

    void SwipeUpdated(DigitalRubyShared.GestureRecognizer gesture)
    {
        SwipeGestureRecognizer swipe = gesture as SwipeGestureRecognizer;
        if (swipe.State == GestureRecognizerState.Ended)
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

    void TapUpdated(DigitalRubyShared.GestureRecognizer gesture)
    {
        Debug.Log(gesture.FocusX);
        if (gesture.State == GestureRecognizerState.Ended)
            if ((gesture as TapGestureRecognizer).TapTouches.Count == 2)
                command.Jump();
    }
}
