using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Command))]
public class InputManager : MonoBehaviour
{
    // A: Touch left/ right screen to move, Swipe to making poses, double click to jump.
    // B: Swipe left-half screen to move and jump, swipe right-half to making poses.
    // C: Swipte screen to move and jump, use right virtual buttons to making poses.
    public enum ControlMethods { TouchScreen_A, TouchScreen_B, TouchScreen_C, TouchPad, Keyboard };
    public GameObject touchPad_L;
    public GameObject touchPad_R;
    public ControlMethods selectedControl = ControlMethods.Keyboard;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedInput"))
            selectedControl = (ControlMethods)GameData.GetSelectedInput();
        SetControl();
    }

    private void SetControl()
    {
        touchPad_L.SetActive(false);
        touchPad_R.SetActive(false);
        foreach (var comp in gameObject.GetComponents<Component>())
            if (!(comp is Transform) && !(comp is InputManager) && !(comp is Command))
                Destroy(comp);

        switch (selectedControl)
        {
            case ControlMethods.TouchScreen_A:
                transform.gameObject.AddComponent<TouchscreenInputHandler_A>();
                break;
            case ControlMethods.TouchScreen_B:
                transform.gameObject.AddComponent<TouchscreenInputHandler_B>();
                break;
            case ControlMethods.TouchScreen_C:
                transform.gameObject.AddComponent<TouchscreenInputHandler_C>();
                touchPad_R.SetActive(true);
                break;
            case ControlMethods.Keyboard:
                transform.gameObject.AddComponent<KeyboardInputHandler>();
                break;
            case ControlMethods.TouchPad:
                touchPad_L.SetActive(true);
                touchPad_R.SetActive(true);
                break;
        }
    }

    public void SwapInputToTouchScreen_A()
    {
        selectedControl = ControlMethods.TouchScreen_A;
        SetControl();
        GameData.SetSelectedInput((int)selectedControl);
    }

    public void SwapInputToTouchScreen_B()
    {
        selectedControl = ControlMethods.TouchScreen_B;
        SetControl();
        GameData.SetSelectedInput((int)selectedControl);
    }

    public void SwapInputToTouchScreen_C()
    {
        selectedControl = ControlMethods.TouchScreen_C;
        SetControl();
        GameData.SetSelectedInput((int)selectedControl);
    }

    public void SwapInputToTouchScreen_Touchpad()
    {
        selectedControl = ControlMethods.TouchPad;
        SetControl();
        GameData.SetSelectedInput((int)selectedControl);
    }
}