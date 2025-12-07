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

    public void ResetEnemyCount()
    {
        enemyCount = 0;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }

    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        enemy.GetComponent<Enemy>().SetSpawner(this);
        
        IncreaseEnemyCount();
    }
}
