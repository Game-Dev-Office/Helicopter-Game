using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public int coins;
    private Text text;
    public GameObject helicopter, RestartButton, StoreButton, AdButton;

    void Start()
    {
        helicopter = GameObject.FindWithTag("Player");

        RestartButton.SetActive(false);
        StoreButton.SetActive(false);
        AdButton.SetActive(false);

        text = GetComponent<Text>();
        text.color = new Color(0, 0, 0, 0);

    }

    void Update()
    {
        helicopter = GameObject.FindWithTag("Player");

        if (helicopter != null)
        {
            coins = PlayerPrefs.GetInt("TotalCoins");
            RestartButton.SetActive(false);
            StoreButton.SetActive(false);
            AdButton.SetActive(false);
            text.color = new Color(0, 0, 0, 0);
        }
        else if (helicopter == null)
        {
            text.color = new Color(0, 0, 0, 1);
            text.text = "Game Over\nYour Score:\n" + coins + " Coins";
            RestartButton.SetActive(true);
            StoreButton.SetActive(true);
            AdButton.SetActive(true);
        }
    }

    public void SetDisable()
    {
        helicopter = GameObject.FindWithTag("Player");
        if (helicopter != null)
        {
            RestartButton.SetActive(false);
            StoreButton.SetActive(false);
            AdButton.SetActive(false);
            text.color = new Color(0, 0, 0, 0);
        }
    }
}
