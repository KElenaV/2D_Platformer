using UnityEngine;
using UnityEngine.Events;

public class Orc : MonoBehaviour
{
    [SerializeField] private UnityEvent _meetPlayer;

    //private PlayerAnimation _player;

    private void Start()
    {
        //_player = FindObjectOfType<PlayerAnimation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _meetPlayer?.Invoke();
            //_player.Die();
        }
    }
}
