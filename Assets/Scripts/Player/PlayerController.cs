using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private int _directionIndex;
    private bool _isGrounded = true;
    private float _rotationAngle;
    private float _leftAngle = 180;
    private float _rightAngle = 0;
    private Direction _curentDirection;
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

        if ((int)_curentDirection != _directionIndex && _directionIndex != 0)
        {
            Return();
        }
    }

    private void Return()
    {
        _rotationAngle = _directionIndex == (int)Direction.Left ? _leftAngle : _rightAngle;
        transform.rotation = Quaternion.Euler(Vector3.up * _rotationAngle);
        _curentDirection = (Direction)_directionIndex;
    }

    private void Move()
    {
        _directionIndex = (int)Input.GetAxisRaw("Horizontal");
        _rigidbody2d.velocity = new Vector2(_directionIndex * _speed, _rigidbody2d.velocity.y);
        float speed = Mathf.Abs(_rigidbody2d.velocity.x);
        _playerAnimation.Run(speed);
    }

    private void Jump()
    {
        _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce);
        _isGrounded = false;
        _onJump?.Invoke();
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
}
