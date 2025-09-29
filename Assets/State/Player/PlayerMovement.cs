using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    public Rigidbody2D RigidBody => _rb;

    [Header("Collider Parametres")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundCheckSize;

    [Header("Player Parametres")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    
    private int _groundLayerIndex;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _groundLayerIndex = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0, _groundLayerIndex);
    }

    public void Move(float direction)
    {
        Mathf.Clamp(_rb.linearVelocityX = direction * _movementSpeed, 0.0f, _movementSpeed);
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
