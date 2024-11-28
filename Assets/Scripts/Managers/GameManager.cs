using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public LevelManager LevelManager { get; private set; }

    // Referensi UI Manager
    public GameUIManager uiManager;

    // Variabel game
    private int playerHealth = 100;
    private int points = 0;
    private int currentWave = 1;
    private int enemiesLeft = 5;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        LevelManager = GetComponentInChildren<LevelManager>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Camera"));
    }

    void Start()
    {
        // Inisialisasi UI saat game dimulai
        if (uiManager != null)
        {
            uiManager.UpdateHealth(playerHealth);
            uiManager.UpdatePoints(points);
            uiManager.UpdateWave(currentWave);
            uiManager.UpdateEnemiesCount(enemiesLeft);
        }
        else
        {
            Debug.LogWarning("UI Manager is not assigned!");
        }
    }

    // Fungsi untuk mengubah health
    public void ChangeHealth(int amount)
    {
        playerHealth += amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100); // Batas minimum 0 dan maksimum 100

        if (uiManager != null)
        {
            uiManager.UpdateHealth(playerHealth);
        }

        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead!");
            // Tambahkan logika untuk menangani game over di sini
        }
    }

    // Fungsi untuk menambah poin
    public void AddPoints(int enemyLevel)
    {
        points += enemyLevel;

        if (uiManager != null)
        {
            uiManager.UpdatePoints(points);
        }
    }

    // Fungsi untuk memperbarui wave
    public void NextWave()
    {
        currentWave++;

        if (uiManager != null)
        {
            uiManager.UpdateWave(currentWave);
        }
    }

    // Fungsi untuk memperbarui jumlah musuh
    public void UpdateEnemiesCount(int count)
    {
        enemiesLeft = count;

        if (uiManager != null)
        {
            uiManager.UpdateEnemiesCount(enemiesLeft);
        }
    }
}
