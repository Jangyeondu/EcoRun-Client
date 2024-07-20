using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // 생성할 코인 프리팹
    public float spawnInterval = 2f; // 코인 생성 간격
    public float destroyX = -10f; // 코인이 사라지는 X 위치
    public float newX = -7f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCoin()
    {
        newX += 2;
        Vector2 spawnPosition = new Vector2(newX, -1f);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity); // 코인 생성
    }
}


