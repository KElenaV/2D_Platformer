using UnityEngine;
using UnityEngine.Events;

public class Killing : MonoBehaviour
{
    [SerializeField] private UnityEvent _meetPlayer;

    private bool _isKilled;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMover player) && _isKilled == false)
        {
            Kill(player);
        }
    }

    private void Kill(PlayerMover player)
    {
        _isKilled = true;
        _meetPlayer?.Invoke();
        LookOnTarget(player.transform);
        player.Die();
    }

    private void LookOnTarget(Transform target)
    {
        int leftDirection = -1;
        int rightDirection = 1;
        float distanse = target.position.x - transform.position.x;
        int toTargetDirection = distanse < 0 ? leftDirection : rightDirection;
        transform.localScale = new Vector3(toTargetDirection, 1, 1);
    }
}
