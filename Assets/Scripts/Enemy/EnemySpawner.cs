using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < defaultSpawnCount + (spawnCount * spawnCountMultiplier); i++)
        {
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
        }
        spawnCount++;
        totalKillWave++;
    }

    public void EnemyDefeated()
    {
        totalKill++;
        if (totalKill % minimumKillsToIncreaseSpawnCount == 0)
        {
            spawnCountMultiplier += multiplierIncreaseCount;
        }
    }
}

