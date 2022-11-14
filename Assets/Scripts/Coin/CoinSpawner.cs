using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Point[] _spawnPoints;

    private int _requiredCoinsCount = 3;
    private int _pointsCount;


    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Point>();
        _pointsCount = _spawnPoints.Length;

        for (int i = 0; i < _requiredCoinsCount;)
        {
            if (CreateOneCoin())
                i++;
        }
    }

    private void Update()
    {
        if(CountCurrentCoins() < 3)
        {
            CreateOneCoin();
        }
    }

    private bool CreateOneCoin()
    {
        Transform parent = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform;

        if (parent.childCount == 0)
        {
            Instantiate(_coinTemplate, parent.position, Quaternion.identity, parent);
            return true;
        }
        return false;
    }

    private int CountCurrentCoins()
    {
        int currentCoinsCount = 0;

        for (int i = 0; i < _pointsCount; i++)
        {
            if (_spawnPoints[i].transform.childCount != 0)
                currentCoinsCount++;
        }
        return currentCoinsCount;
    }
}
