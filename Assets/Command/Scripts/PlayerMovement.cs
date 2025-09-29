using UnityEngine;

namespace Patterns.Command
{
    public class PlayerMovement : MonoBehaviour
    {
        public void Move(Vector3 moveVector)
        {
            Vector3 destination = transform.position + moveVector;
            transform.position = destination;
        }
    }
}