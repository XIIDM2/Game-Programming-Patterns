using UnityEngine;

namespace Patterns.Flyweight
{
    public class Shape : MonoBehaviour
    {
        [SerializeField] private ShapesData _data;

        [SerializeField] private int _health;
        [SerializeField] private float _movementSpeed;

        private void Start()
        {
            _health = _data.Health;
            _movementSpeed = _data.MovementSpeed;
        }
    }
}