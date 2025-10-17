using UnityEngine;

namespace Patterns.FSM
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        public float LastDirection { get; private set; }
        public Vector2 Velocity => _rb.linearVelocity;

        [Header("Collider Parametres")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Vector2 _groundCheckSize;

        [Header("Player Parametres")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpForce;

        private int _groundLayerIndex;

        private Rigidbody2D _rb;
        private ChangeObjectDirection _changeObjectDirection;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _changeObjectDirection = GetComponent<ChangeObjectDirection>();
        }

        private void Start()
        {
            _groundLayerIndex = LayerMask.GetMask("Ground");
        }

        private void Update()
        {
            IsGrounded = Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0, _groundLayerIndex);


            _changeObjectDirection.FaceDirection(_rb.linearVelocityX);
        }

        public void SetLastDirection(float value)
        {
            LastDirection = value;
        }

        public void Move(float direction)
        {
            _rb.linearVelocityX = Mathf.Clamp(direction * _movementSpeed, -_movementSpeed, _movementSpeed);
        }

        public void Jump()
        {
            _rb.AddForce(new Vector2(_rb.linearVelocityX, _jumpForce), ForceMode2D.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
        }
    }
}