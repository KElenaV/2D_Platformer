using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OrcAttack : MonoBehaviour
{
    private Animator _animator;
    private int hitHash = Animator.StringToHash("Hit");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        _animator.SetTrigger(hitHash);
    }
}
