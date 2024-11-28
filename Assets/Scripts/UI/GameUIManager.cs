using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text pointsText;
    public TMP_Text waveText;
    public TMP_Text enemiesText;

    public void UpdateHealth(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void UpdatePoints(int points)
    {
        pointsText.text = "Points: " + points;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void UpdateEnemiesCount(int enemiesLeft)
    {
        enemiesText.text = "Enemies Left: " + enemiesLeft;
    }
}
