using UnityEngine;

public enum States
{ 
    Idle,
    Run,
    Attack,
    Die
}


public class StateObject : MonoBehaviour
{
    [SerializeField] private States _state;
    
    void Start()
    {
        SetCurrentState(States.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case States.Idle:
                Debug.Log("State: Idle");
                break;
            case States.Run:
                Debug.Log("State: Run");
                break;
            case States.Attack:
                Debug.Log("State: Attack");
                break;
            case States.Die:
                Debug.Log("State: Die");
                break;
                default:
                Debug.Log("State not Implemented");
                break;
        }
    }

    public void SetCurrentState(States state)
    {
        if (_state == state) return;

        _state = state;
    }

    public void SetIdleState()
    {
        _state = States.Idle;
    }

    public void SetRunState()
    {
        _state = States.Run;
    }

    public void SetAttackState()
    {
        _state = States.Attack;
    }

    public void SetDieState()
    {
        _state = States.Die;
    }
}