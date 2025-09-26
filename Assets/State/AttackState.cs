using UnityEngine;

public class AttackState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Attack state");
    }
    public void Update()
    {
        Debug.Log("In Attack state");
    }

    public void Exit()
    {
        Debug.Log("Exit Attack state");
    }

}
