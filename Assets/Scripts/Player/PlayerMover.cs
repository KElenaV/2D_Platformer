using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private int _inputDirection;
    private int _currentDirection;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2d;
    private PlayerAnimation _playerAnimation;

    [SerializeField] private UnityEvent _onJump;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
        Move();

        if(_inputDirection != _currentDirection && _inputDirection != 0)
        {
            Return();
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        float maxGroundAngle = 10;

        if (collision.gameObject.TryGetComponent(out Floor floor))
        {
            if (Vector2.Angle(collision.contacts[0].normal, Vector2.up) <= maxGroundAngle)
            {
                _isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor))
            _isGrounded = false;
    }

    public void Die()
    {
        _playerAnimation.Die();
        Destroy(gameObject, 3.5f);
    }

    private void Jump()
    {
        _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce);
        _isGrounded = false;
        _onJump?.Invoke();
    }

    private void Return()
    {
        transform.localScale = new Vector3(_inputDirection, 1, 1);
        _currentDirection = _inputDirection;
    }

    private void Move()
    {
        _inputDirection = (int)Input.GetAxisRaw("Horizontal");
        _rigidbody2d.velocity = new Vector2(_inputDirection * _speed, _rigidbody2d.velocity.y);
        float speed = Mathf.Abs(_rigidbody2d.velocity.x);
        _playerAnimation.Run(speed);
    }
}
