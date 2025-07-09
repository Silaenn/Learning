using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    ICommand moveForwardCommand;
    ICommand moveBackwardCommand;
    List<ICommand> commandHistory = new List<ICommand>();

    void Start()
    {
        moveForwardCommand = new Command(transform, Vector3.forward);
        moveBackwardCommand = new Command(transform, Vector3.back);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveForwardCommand.Execute();
            commandHistory.Add(moveForwardCommand);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveBackwardCommand.Execute();
            commandHistory.Add(moveBackwardCommand);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (commandHistory.Count > 0)
            {
                ICommand lastCommand = commandHistory[commandHistory.Count - 1];
                lastCommand.Undo();
                commandHistory.RemoveAt(commandHistory.Count - 1);
            }
        }
    }
}
