using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // 积己且 内牢 橇府普
    public GameObject enemyPrefab; // 积己且 利 橇府普
    public float spawnInterval = 4f; // 内牢 积己 埃拜
    public float destroyX = -10f; // 内牢捞 荤扼瘤绰 X 困摹
    public float newX = -7f;
    public float newY = 0f;
    public float spawnItem = 0f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        spawnItem = Random.Range(0, 2);
        Debug.Log(spawnItem);
        if (Time.time > nextSpawnTime)
        {
            if(spawnItem == 0)
            {
                SpawnCoin();
            }
            else
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnCoin()
    {
        newY = Random.Range(-1f, 1f);
        newX += 1;
        Vector2 spawnPosition = new Vector2(newX, newY);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity); // 内牢 积己
    }

    void SpawnEnemy()
    {
        newY = Random.Range(-1f, 1f);
        newX += 1;
        Vector2 spawnPosition = new Vector2(newX, newY);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // 内牢 积己
    }
}


