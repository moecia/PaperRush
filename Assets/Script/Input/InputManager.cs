using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Command))]
public class InputManager : MonoBehaviour
{
    public enum ControlMethods { TouchScreen_A, TouchScreen_B, TouchPad, Keyboard, Any };
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
            case ControlMethods.Any:
                transform.gameObject.AddComponent<KeyboardInputHandler>();
                transform.gameObject.AddComponent<TouchscreenInputHandler_A>();
                transform.gameObject.AddComponent<TouchscreenInputHandler_B>();
                break;
        }
    }


}