using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject spawnedEnemy;

    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waveInterval)
        {
            StartNewWave();
            timer = 0;
        }
    }

    private void StartNewWave()
    {
        waveNumber++;
        foreach (var spawner in enemySpawners)
        {
            spawner.spawnCountMultiplier++;
            spawner.StartSpawning();
        }
    }

    public void EnemyDefeated()
    {
        totalEnemies--;
        if (totalEnemies <= 0)
        {
            Debug.Log("Wave Complete!");
        }
    }
}

