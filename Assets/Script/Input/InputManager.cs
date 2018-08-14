using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Command))]
public class InputManager : MonoBehaviour
{
    // A: Touch left/ right screen to move, Swipe to making poses, double click to jump.
    // B: Swipe left-half screen to move and jump, swipe right-half to making poses.
    // C: Swipte left-half screen to move and jump, use right virtual buttons to making poses.
    public enum ControlMethods { TouchScreen_A, TouchScreen_B, TouchScreen_C, TouchPad, Keyboard, Any };
    public ControlMethods selectedControl = ControlMethods.Keyboard;

    // Use this for initialization
    void Start()
    { 
        switch (selectedControl)
        {
            case ControlMethods.Keyboard:
                transform.gameObject.AddComponent<KeyboardInputHandler>();
                break;
            case ControlMethods.TouchScreen_A:
                transform.gameObject.AddComponent<TouchscreenInputHandler_A>();
                break;
            case ControlMethods.TouchScreen_B:
                transform.gameObject.AddComponent<TouchscreenInputHandler_B>();
                break;
            case ControlMethods.TouchScreen_C:
                transform.gameObject.AddComponent<TouchscreenInputHandler_C>();
                break;
            case ControlMethods.Any:
                transform.gameObject.AddComponent<KeyboardInputHandler>();
                transform.gameObject.AddComponent<TouchscreenInputHandler_A>();
                transform.gameObject.AddComponent<TouchscreenInputHandler_B>();
                break;
        }
    }


}