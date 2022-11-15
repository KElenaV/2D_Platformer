using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Point[] _spawnPoints;

    private int _requiredCoinsCount = 3;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Point>();

        CreateCoins(_requiredCoinsCount);
    }

    public void CreateCoins(int coinsCount)
    {
        for (int i = 0; i < coinsCount;)
        {
            if (TryCreateOneCoin())
                i++;
        }
    }

    private bool TryCreateOneCoin()
    {
        Transform parent = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform;

        if (parent.childCount == 0)
        {
            Instantiate(_coinTemplate, parent.position, Quaternion.identity, parent);
            return true;
        }
        return false;
    }
}
