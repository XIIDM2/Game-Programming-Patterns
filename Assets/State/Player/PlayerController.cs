using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Patterns.FSM
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement Movement { get; private set; }
        public PlayerAttack Attack { get; private set; }
        public PlayerAnimatiion Animation { get; private set; }

        private FiniteStateMachine _movementMachine;
        private FiniteStateMachine _poseMachine;
        private FiniteStateMachine _attackMachine;

        private List<FiniteStateMachine> _stateMachines = new List<FiniteStateMachine>();

        private PlayerInputController _inputController;

        private void Awake()
        {
            _inputController = GetComponent<PlayerInputController>();

            Movement = GetComponent<PlayerMovement>();
            Attack = GetComponent<PlayerAttack>();

            Animation = GetComponentInChildren<PlayerAnimatiion>();
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
            _movementMachine = new FiniteStateMachine();
            _movementMachine.FSMInitialize(this, new IdleState());

            _poseMachine = new FiniteStateMachine();
            _poseMachine.FSMInitialize(this, new StandingState());

            _attackMachine = new FiniteStateMachine();
            _attackMachine.FSMInitialize(this, new NonAttackState());

            _stateMachines.Add(_movementMachine);
            _stateMachines.Add(_poseMachine);
            _stateMachines.Add(_attackMachine);
        }

        private void Update()
        {
            foreach (FiniteStateMachine stateMachine in _stateMachines)
            {
                stateMachine.FSMUpdate(this);
            }
        }

        private void FixedUpdate()
        {
            foreach (FiniteStateMachine stateMachine in _stateMachines)
            {
                stateMachine.FSMFixedUpdate(this);
            }
        }

        public void HandleInput(InputData inputData)
        {
            foreach (FiniteStateMachine stateMachine in _stateMachines)
            {
                stateMachine.HandleInput(this, inputData);
            }
        }
    }
}