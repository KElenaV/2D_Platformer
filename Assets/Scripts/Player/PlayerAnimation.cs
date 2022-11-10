using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private int _deadHash = Animator.StringToHash("Dead");
    private int _speedHash = Animator.StringToHash("Speed");
    private int _jumpHash = Animator.StringToHash("Jump");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.SetTrigger(_jumpHash);
    }

    public void Die()
    {
        _animator.SetTrigger(_deadHash);
    }

    public void Run(float speed)
    {
        _animator.SetFloat(_speedHash, speed);
    }
}
