using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinMakeScript : MonoBehaviour
{
    public GameObject coinPrefab; // 생성할 코인 프리팹
    public GameObject enemyPrefab; // 생성할 적 프리팹
    public float spawnInterval = 0.5f; // 코인 및 적 생성 간격
    public float spawnHeight = 1f; // 생성되는 높이의 범위
    public float nextSpawnTime = 0f;
    public float moveSpeed = 5f; // 오브젝트 이동 속도

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnRandomObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnRandomObject()
    {
        Vector2 spawnPosition = new Vector2(4f, (int)Random.Range(-2f, -1f));
        GameObject spawnedObject;

        if (Random.Range(0f, 1f) < 0.8f)
        {
            spawnedObject = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            spawnedObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        spawnedObject.AddComponent <ScrollLeft>().moveSpeed = moveSpeed;
    }
}
