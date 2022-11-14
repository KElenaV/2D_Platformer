using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.DOFade(0, 1.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<CoinSound>().GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
