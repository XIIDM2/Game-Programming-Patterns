using UnityEngine;

namespace Patterns.Command
{
    public class MoveCommand : ICommand
    {
        private PlayerMovement _player;
        private Vector3 _moveVector;
        private Vector3 _previousPosition;

        public MoveCommand(PlayerMovement player, Vector3 moveVector)
        {
            _player = player;
            _moveVector = moveVector;
        }

        public void Execute()
        {
            _previousPosition = _player.transform.position;
            _player.Move(_moveVector);
        }

        public void Undo()
        {
            _player.transform.position = _previousPosition;
        }
    }
}