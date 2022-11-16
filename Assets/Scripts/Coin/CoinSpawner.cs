using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;

    private int _maxCoinNumber;
    private Point[] _spawnPoints;
    private int _requiredCoinsCount = 3;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Point>();
        _maxCoinNumber = _spawnPoints.Length;

        CreateCoins(_requiredCoinsCount);
    }

    public void CreateCoins(int coinsCount)
    {
        coinsCount = coinsCount > _maxCoinNumber ? _maxCoinNumber : coinsCount;

        for (int i = 0; i < coinsCount;)
        {
            Transform parent = _spawnPoints[Random.Range(0, _maxCoinNumber)].transform;

            if(parent.childCount == 0)
            {
                Instantiate(_coinTemplate, parent.position, Quaternion.identity, parent);
                i++;
            }
        }
    }
}
