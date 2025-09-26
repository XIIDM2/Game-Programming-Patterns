using UnityEngine;

public class IdleState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Idle state");
    }
    public void Update()
    {
        Debug.Log("In Idle state");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle state");
    }

}
