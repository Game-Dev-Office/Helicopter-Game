using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    public void RestartGame()
    {
        PlayerPrefs.SetInt("TotalCoins", 0);
        SceneManager.LoadScene("Main");

        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
}
