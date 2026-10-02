using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnDistance = 8f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxEnemies = 20;

    private float spawnTimer;

    private void Update()
    {
        if (player == null || enemyPrefab == null)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
            return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector3 spawnPosition = player.position +
                                new Vector3(randomDirection.x, 0f, randomDirection.y) *
                                spawnDistance;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}