using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int _initialCoinsNumber;
    [SerializeField] private Coin[] _allCoins;
    
    private int _maxCoinNumber;

    private void Awake()
    {
        _allCoins = GetComponentsInChildren<Coin>(true);
        _maxCoinNumber = _allCoins.Length;
        
        CreateCoins();
    }

    private void OnEnable()
    {
        foreach (var coin in _allCoins)
        {
            coin.Collected += CreateOneCoin;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in _allCoins)
        {
            coin.Collected -= CreateOneCoin;
        }
    }

    public void CreateOneCoin()
    {
        Coin coin = FindCoinOrDefault();

        if(coin != null)
            coin.gameObject.SetActive(true);
    }

    private Coin FindCoinOrDefault()
    {
        List<Coin> freeCoins = new();
        freeCoins = _allCoins.Where(coin => coin.isActiveAndEnabled == false).ToList();

        if(freeCoins.Count == 0)
        {
            return null;
        }

        Coin freeCoin = freeCoins[Random.Range(0, freeCoins.Count)];

        return freeCoin;
    }

    private void CreateCoins()
    {
        if (_initialCoinsNumber > _maxCoinNumber)
            _initialCoinsNumber = _maxCoinNumber;

        for (int i = 0; i < _initialCoinsNumber; i++)
        {
            CreateOneCoin();
        }
    }
}
