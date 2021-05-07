using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store_Button : MonoBehaviour
{
    public int coin, i;
    public GameObject ShopPanel;
    public Button[] Btn;
    public GameObject[] SelectBtn;
    public Text CoinText;
    public int Prefab;


    void Start()
    {
        Prefab = 0;

        for (i = 0; i < Btn.Length; i++)
        {
            if (!PlayerPrefs.HasKey(Btn[i].name))
                PlayerPrefs.SetInt(Btn[i].name, 0);
            else
                if (PlayerPrefs.GetInt(Btn[i].name) == 1)
            {
                Btn[i].gameObject.SetActive(false);
                SelectBtn[i].gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (Prefab == 1)
        {
            Prefab = 0;
            PlayerPrefs.DeleteAll();
        }

        coin = PlayerPrefs.GetInt("TotalCoins");
        CoinText.text = coin.ToString();

        for (i = 0; i < Btn.Length; i++)
        {
            if (Btn[i] != null)
            {
                Btn[i].GetComponent<Button>();
                int price = Convert.ToInt32(Btn[i].GetComponentInChildren<Text>().text);

                if (price > PlayerPrefs.GetInt("TotalCoins"))
                    Btn[i].interactable = false;
                else if (price <= PlayerPrefs.GetInt("TotalCoins"))
                    Btn[i].interactable = true;
            }
        }
    }

    public void ShopOpen()
    {
        ShopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShopClose()
    {
        ShopPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Purchase(string value)
    {
        string HelicopterName = EventSystem.current.currentSelectedGameObject.name;

        i = 0;
        
        foreach (Button btn in Btn)
        {
            if (HelicopterName == btn.name)
            {
                PlayerPrefs.SetInt(HelicopterName, 1);
                btn.gameObject.SetActive(false);
                SelectBtn[i].SetActive(true);
            }
            i++;
        }

        int price = Convert.ToInt32(value);
        coin = PlayerPrefs.GetInt("TotalCoins");
        coin -= price;
        CoinText.text = coin.ToString();

        PlayerPrefs.SetInt("TotalCoins", coin);
        PlayerPrefs.Save();
    }


    public void SelectFunction(string value)
    {
        PlayerPrefs.SetString("HCName", value);
        PlayerPrefs.Save();
        GameObject.Find("Panel_Shop").SetActive(false);
    }
}
