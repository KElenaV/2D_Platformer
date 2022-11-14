using UnityEngine;
using UnityEngine.Events;

public class Killing : MonoBehaviour
{
    [SerializeField] private UnityEvent _meetPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMover player))
        {
            Kill(player);
        }
    }

    private void Kill(PlayerMover player)
    {
        _meetPlayer?.Invoke();
        LookOnTarget(player.transform);
        player.Die();
    }

    private void LookOnTarget(Transform target)
    {
        var XAxisOrientation = 90;
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - XAxisOrientation;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
