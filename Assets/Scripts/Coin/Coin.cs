using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Start()
    {
        Blink();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Delete();
        GetComponentInParent<CoinSpawner>().CreateOneCoin();
    }

    private void Blink()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.DOFade(0, 1.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void Delete()
    {
        GetComponentInParent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
