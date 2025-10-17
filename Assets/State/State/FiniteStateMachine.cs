using UnityEngine;

namespace Patterns.FSM
{
    public class FiniteStateMachine
    {
        private State _currentState;
        public void FSMInitialize(PlayerController controller, State initState)
        {
            _currentState = initState;
            _currentState.Enter(controller);
        }

        public void FSMUpdate(PlayerController controller)
        {
            Debug.Log(_currentState);

            State newState = _currentState.HandleTransition(controller);

            if (newState != null)
            {
                ChangeState(controller, newState);
            }
            else
            {
                _currentState.Update(controller);
            }
        }

        public void FSMFixedUpdate(PlayerController controller)
        {
            _currentState.FixedUpdate(controller);
        }

        public void HandleInput(PlayerController controller, InputData inputData)
        {
            State newState = _currentState.HandleInput(controller, inputData);

            ChangeState(controller, newState);
        }

        private void ChangeState(PlayerController controller, State state)
        {
            if (state != null && state != _currentState)
            {
                _currentState.Exit(controller);
                _currentState = state;
                _currentState.Enter(controller);
            }
        }
    }
}