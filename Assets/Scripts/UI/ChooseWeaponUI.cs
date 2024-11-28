using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseWeaponUI : MonoBehaviour
{
    // Fungsi dipanggil ketika tombol ditekan
    public void StartGame()
    {
        SceneManager.LoadScene("Main"); // Ganti "Main" dengan nama scene Main Anda
    }
}
