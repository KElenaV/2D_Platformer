using UnityEngine;

public class OrcMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;
    [SerializeField] private Direction _currentDirection;

    private bool _isStopped;
    private float _leftEulerY = 180;
    private float _rightEuler = 0;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

    private void Update()
    {
        Walk();
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
                    ChangeDirection(Direction.Right, _rightEuler);
                }
            }
            else
            {
                if (transform.position.x > _rightTarget.position.x)
                {
                    ChangeDirection(Direction.Left, _leftEulerY);
                }
            }
        }
    }

    private void ChangeDirection(Direction direction, float rotationEulerY)
    {
        _currentDirection = direction;
        transform.rotation = Quaternion.Euler(Vector3.up * rotationEulerY);
    }

    public void Stop()
    {
        _isStopped = true;
    }
}
