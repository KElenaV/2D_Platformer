using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    private SpriteRenderer _renderer;

    public event UnityAction Collected;

    private void Start()
    {
        Blink();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMover player))
        {
            DeleteFromScene();
            Collected?.Invoke();
        }
    }

    private void Blink()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.DOFade(0, 1.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void DeleteFromScene()
    {
        GetComponentInParent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}
