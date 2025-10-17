namespace Patterns.FSM
{
    public abstract class State
    {
        public virtual State HandleInput(PlayerController controller, InputData inputData) => null;
        public virtual State HandleTransition(PlayerController controller) => null;
        public virtual void Enter(PlayerController controller) { }
        public virtual void Update(PlayerController controller) { }
        public virtual void FixedUpdate(PlayerController controller) { }
        public virtual void Exit(PlayerController controller) { }
    }
}