using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement Movement { get; private set; }

    private PlayerInputController _inputController;
    private State _currentState;

    private void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
        _inputController = GetComponent<PlayerInputController>();
    }

    private void OnEnable()
    {
        _inputController.ActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        _inputController.ActionTriggered -= HandleInput;
    }

    private void Start()
    {
        _currentState = new IdleState();
        _currentState.Enter(this);
    }

    private void Update()
    {
        Debug.Log(_currentState);
        _currentState.Update(this);
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdate(this);
    }

    public void HandleInput(InputData inputData)
    {
        State newState = _currentState.HandleInput(this, inputData);

        ChangeState(newState);
    }

    public void ChangeState(State state)
    {
        if (state != null)
        {
            _currentState.Exit(this);
            _currentState = state;
            _currentState.Enter(this);
        }
    }
}
