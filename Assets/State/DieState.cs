using UnityEngine;

public class DieState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Die state");
    }
    public void Update()
    {
        Debug.Log("In Die state");
    }

    public void Exit()
    {
        Debug.Log("Exit Die state");
    }
}
