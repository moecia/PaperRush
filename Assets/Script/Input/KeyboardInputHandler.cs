using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour
{
    public Command command;

    private void Start()
    {
        command = transform.GetComponent<Command>();
    }

    // Update is called once per frame
    void Update ()
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
