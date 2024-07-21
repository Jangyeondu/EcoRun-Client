using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // ������ ���� ������
    public GameObject enemyPrefab; // ������ �� ������
    public float spawnInterval = 0.5f; // ���� �� �� ���� ����
    public float spawnHeight = 1f; // �����Ǵ� ������ ����
    private float nextSpawnTime = 0f;
    public float moveSpeed = 5f; // ������Ʈ �̵� �ӵ�

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
        Vector2 spawnPosition = new Vector2(4f, Random.Range(-2f, -1f));
        GameObject spawnedObject;

        if (Random.Range(0f, 1f) < 0.5f)
        {
            spawnedObject = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            spawnedObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        spawnedObject.AddComponent<MoveLeft>().moveSpeed = moveSpeed;
    }
}
