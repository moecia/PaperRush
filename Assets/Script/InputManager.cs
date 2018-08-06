using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Command command;
    public enum M_Platform { iOS, Android, PC };
    public M_Platform selectedPlatform = M_Platform.PC;
    // Use this for initialization
    void Start()
    {
        if (!command)
        {
            print("Command methods not found, you must assign one.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (selectedPlatform)
        {
            case M_Platform.PC:
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
}
