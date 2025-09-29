using UnityEngine;

public abstract class State
{
    protected const float ZERO_MOVEMENT_SPEED = 0.0f;

    protected const float AIR_MOVEMENT_MODIFIER = 0.7f;

    protected float _direction = 0.0f;

    public State(float direction = 0.0f)
    {
        _direction = direction;
    }

    public virtual State HandleInput(PlayerController controller, InputData inputData) => null;
    public virtual void Enter(PlayerController controller) { }
    public virtual void Update(PlayerController controller) { }
    public virtual void FixedUpdate(PlayerController controller) { }
    public virtual void Exit(PlayerController controller) { }
}
