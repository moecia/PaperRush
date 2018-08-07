using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DigitalRubyShared;

[RequireComponent(typeof(Command))]
public class InputManager : MonoBehaviour {

    public Command command;
    public enum ControlMethods { TouchScreen, TouchPad, Keyboard, Any };
    public ControlMethods selectedControl = ControlMethods.Keyboard;

    [Header("Touchscreen Inputs")]
    private int swipeTouchCount = 1;
    [Tooltip("Controls how the swipe gesture ends. See SwipeGestureRecognizerSwipeMode enum for more details.")]
    public SwipeGestureRecognizerEndMode swipeMode = SwipeGestureRecognizerEndMode.EndImmediately;
    private SwipeGestureRecognizer swipe;

    // Use this for initialization
    void Start()
    {
        if (!command)
        {
            print("Command methods not found, you must assign one.");
        }
        InitializeTouchScreenInput();
    }

    void InitializeTouchScreenInput()
    {
        swipe = new SwipeGestureRecognizer();
        swipe.StateUpdated += SwipeUpdated;
        swipe.DirectionThreshold = 0;
        swipe.MinimumNumberOfTouchesToTrack = swipe.MaximumNumberOfTouchesToTrack = swipeTouchCount;
        FingersScript.Instance.AddGesture(swipe);
        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.StateUpdated += TapUpdated;
        FingersScript.Instance.AddGesture(tap);
    }

    void SwipeUpdated(DigitalRubyShared.GestureRecognizer gesture)
    {
        SwipeGestureRecognizer swipe = gesture as SwipeGestureRecognizer;
        if (swipe.State == GestureRecognizerState.Ended)
        {
            ScreenInput();
        }
    }

    void TapUpdated(DigitalRubyShared.GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
            Debug.Log("Tap");
    }

    // Update is called once per frame
    void Update()
    {
        swipe.MinimumNumberOfTouchesToTrack = swipe.MaximumNumberOfTouchesToTrack = swipeTouchCount;
        swipe.EndMode = swipeMode;

        switch (selectedControl)
        {
            case ControlMethods.Keyboard:
                KeyboardInput();
                break;
        }
    }

    private void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            command.MoveLeft();
        else if (Input.GetKeyDown(KeyCode.D))
            command.MoveRight();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            command.MakePoseUp();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            command.MakePoseDown();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            command.MakePoseLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            command.MakePoseRight();
        else if (Input.GetKeyDown(KeyCode.Space))
            command.Jump();
    }

    private void ScreenInput()
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