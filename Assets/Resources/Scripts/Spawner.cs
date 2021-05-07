using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Dag;
    public GameObject Road;
    public GameObject Airplanes;
    public GameObject[] Coins;
    public GameObject[] House;
    public GameObject[] Cloud;
    //public GameObject[] Gas;
    public static float speed = 25f;
    public GameObject Player;
    GameObject go;
    string HCName, path;
    int sayac, rnd;

    void Start()
    {
        SpawnRoad();
        StartCoroutine(SpawnDag());
        StartCoroutine(SpawnAirplanes());
        StartCoroutine(SpawnCoins());
        StartCoroutine(SpawnHouse());
        StartCoroutine(SpawnCloud());
        //StartCoroutine(SpawnGas());

        if (PlayerPrefs.HasKey("HCName"))
        {
            HCName = PlayerPrefs.GetString("HCName");
            path = "PlayerPrefs/" + HCName;
        }
        else
            path = "PlayerPrefs/HC";

        Player = Instantiate(Resources.Load<GameObject>(path));
        Player.AddComponent<HeliController>();
    }

    private void Update()
    {
        if (go.transform.position.x <= 106.6f)
            SpawnRoad();
    }

    IEnumerator SpawnAirplanes()
    {
        while (true)
        {
            Instantiate(Airplanes, new Vector3(93, Random.Range(0, 30), 93f),
                Quaternion.Euler(0f, 0f, 0f));

            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            sayac = 10;
            //int coinsThisRow = Random.Range(2, 4);

            //for (int i = 0; i < coinsThisRow; i++)
            //    Instantiate(Coins[Random.Range(0, Coins.Length)], new Vector3(110, Random.Range(-10, 20), 93), Quaternion.identity);

            for (sayac = 00; sayac < 30; sayac += 10)
            {
                rnd = Random.Range(0, 2);
                if (rnd == 1)
                    Instantiate(Coins[Random.Range(0, Coins.Length)], new Vector3(110, sayac, 93), Quaternion.identity);
            }

            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }

    //IEnumerator SpawnGas()
    //{
    //    while (true)
    //    {
    //        // number of gas we could spawn vertically
    //        int gasThisRow = Random.Range(1, 2);

    //        // instantiate all gas in this row separated by some random amount of space
    //        for (int i = 0; i < gasThisRow; i++)
    //            Instantiate(Gas[Random.Range(0, Gas.Length)], new Vector3(110, Random.Range(-10, 20), 93), Quaternion.Euler(-90f, 0f, 90f));

    //        // pause 1-5 seconds until the next gas spawns
    //        yield return new WaitForSeconds(Random.Range(1, 5));
    //    }
    //}

    IEnumerator SpawnHouse()
    {
        while (true)
        {
            Instantiate(House[Random.Range(0, House.Length)], new Vector3(110, -34, 93),
                Quaternion.Euler(90f, 0f, 0f));

            yield return new WaitForSeconds(Random.Range(1.5f, 5));
        }
    }

    IEnumerator SpawnDag()
    {
        while (true)
        {
            
            Instantiate(Dag, new Vector3(300, Random.Range(-87, -22), Random.Range(346, 203)),
                Quaternion.Euler(-90f, 0f, 0f));

            
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }

    IEnumerator SpawnCloud()
    {
        while (true)
        {
            Instantiate(Cloud[Random.Range(0, Cloud.Length)], new Vector3(300, Random.Range(5, 37), Random.Range(350, 110)),
                Quaternion.Euler(-90f, 0f, 0f));

            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }

    void SpawnRoad()
    {
        go = Instantiate(Road, new Vector3(606f, -27f, 64.5f), Quaternion.Euler(0f, 0f, 0f));
    }
}
