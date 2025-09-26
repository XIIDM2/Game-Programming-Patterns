using UnityEngine;

public class RunState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Run state");
    }
    public void Update()
    {
        Debug.Log("In Run state");
    }

    public void Exit()
    {
        Debug.Log("Exit Run state");
    }

}
