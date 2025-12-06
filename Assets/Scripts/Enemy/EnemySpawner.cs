using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnInterval = 2f;
    [SerializeField]
    private int maxEnemies = 10;

    private float timer;
    private int enemyCount = 0;

    void Update()
    {
        if (enemyCount >= maxEnemies) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyCount++;
    }

    
}
