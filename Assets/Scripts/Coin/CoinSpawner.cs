using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private int _initialNumberCoins;

    private Point[] _spawnPoints;
    private Transform _free;
    private int _maxCoinNumber;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Point>();
        _maxCoinNumber = _spawnPoints.Length;

        CreateCoins();
    }

    public void CreateOneCoin()
    {
        GetFreePosition();
        Instantiate(_coinTemplate, _free.position, Quaternion.identity, _free);
    }

    private void CreateCoins()
    {
        if (_initialNumberCoins > _maxCoinNumber)
            _initialNumberCoins = _maxCoinNumber;

        for (int i = 0; i < _initialNumberCoins; i++)
        {
            CreateOneCoin();
        }
    }

    private void GetFreePosition()
    {
        do
        {
            _free = _spawnPoints[Random.Range(0, _maxCoinNumber)].transform;
        }
        while (_free.childCount != 0);
    }
}
