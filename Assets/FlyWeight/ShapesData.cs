using UnityEngine;

namespace Patterns.Flyweight
{
    [CreateAssetMenu(fileName = "ShapesData", menuName = "Scriptable Objects/ShapesData")]

    public class ShapesData : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private float movementSpeed;

        public int Health => health;
        public float MovementSpeed => movementSpeed;

    }
}