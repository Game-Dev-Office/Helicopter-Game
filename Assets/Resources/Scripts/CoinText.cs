using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
	public Text[] TextCoin;

    void Update ()
    {
        foreach (Text txt in TextCoin)
        {
            txt.GetComponent<Text>();
            txt.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        }
	}
}
