using UnityEngine;

public class OrcMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;
    [SerializeField] private Direction _currentDirection;

    private bool _isStopped;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

    private void Update()
    {
        Walk();
    }

    public void Stop()
    {
        _isStopped = true;
    }

    private void Walk()
    {
        if (_isStopped == false)
        {
            transform.position += Vector3.right * (int)_currentDirection * _speed * Time.deltaTime;

            if (_currentDirection == Direction.Left)
            {
                if (transform.position.x < _leftTarget.position.x)
                {
                    ChangeDirection(Direction.Right);
                }
            }
            else
            {
                if (transform.position.x > _rightTarget.position.x)
                {
                    ChangeDirection(Direction.Left);
                }
            }
        }
    }

    private void ChangeDirection(Direction direction)
    {
        _currentDirection = direction;
        transform.localScale = new Vector3((int)direction, 1, 1);
    }

    enum Direction
    {
        Left = -1,
        Right = 1
    }
}
