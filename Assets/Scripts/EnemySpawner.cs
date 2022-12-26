using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnRadius = 70.0f;
    public int maxEnemies = 10;
    public float spawnInterval = 5.0f;
    public float spawnIntervalIncrement = 0.1f; 
    
    private float lastSpawnTime;
    private int numEnemiesSpawned; 

    void Update()
    {
        if (!(Time.time - lastSpawnTime >= spawnInterval) || numEnemiesSpawned >= maxEnemies) return;
        Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = transform.position.y;
        if (!IsValidSpawnLocation(spawnPos)) return;
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                
        lastSpawnTime = Time.time;
        numEnemiesSpawned++;
                
        spawnInterval += spawnIntervalIncrement;
    }

    public void DecreaseEnemyNum()
    {
        numEnemiesSpawned--;
    }

    bool IsValidSpawnLocation(Vector3 pos)
    {
        return true;
    }
}
