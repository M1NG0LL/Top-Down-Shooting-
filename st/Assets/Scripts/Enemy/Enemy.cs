using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 0.7f;

    private float finalSpeed;
    private EnemySpawner spawner;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        finalSpeed = speed;

        ApplySpeedBoost();
    }
    
    void Update()
    {
        if (player == null)
            return;

        Vector2 direction = (player.transform.position - transform.position).normalized;

        transform.position += (Vector3)(direction * finalSpeed * Time.deltaTime);
    }

    public void SetSpawner(EnemySpawner spawnerRef)
    {
        spawner = spawnerRef;
    }

    private void ApplySpeedBoost()
    {
        int score = GameManager.Instance.score;

        float speedBoost = Mathf.Clamp(score * 0.005f, 0f, 0.4f); 

        if (Random.value < speedBoost)
        {
            float boost = 1f + (score * 0.002f);  
            finalSpeed *= boost;

            finalSpeed = Mathf.Clamp(finalSpeed, speedBoost, speedBoost * 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawner.DecreaseEnemyCount();
            GameManager.Instance.AddScore(10);
        }
    }
}
