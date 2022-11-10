using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public bool _isGrounded;
    private Rigidbody2D _rigidbody2d;
    private PlayerAnimation _playerAnimation;

    [SerializeField] private UnityEvent _onJump;

    public float RunSpeed { get; private set; }

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _onJump?.Invoke();
            _isGrounded = false;
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce);
        }
        _rigidbody2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rigidbody2d.velocity.y);
        float speed = Mathf.Abs(_rigidbody2d.velocity.x);
        _playerAnimation.Run(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float maxGroundAngle = 10; 

        if(collision.gameObject.TryGetComponent(out Floor floor))
        {
            if(Vector2.Angle(collision.contacts[0].normal, Vector2.up) <= maxGroundAngle)
            {
                _isGrounded = true;
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject, 3.5f);
    }
}
