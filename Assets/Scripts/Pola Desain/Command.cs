using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}
public class Command : ICommand
{
    Transform playerTransform;
    Vector3 movement;
    Vector3 previousPosition;

    public Command(Transform transform, Vector3 movement)
    {
        this.playerTransform = transform;
        this.movement = movement;
        this.previousPosition = transform.position;
    }

    public void Execute()
    {
        playerTransform.position += movement;
    }

    public void Undo()
    {
        playerTransform.position = previousPosition;
    }
}
