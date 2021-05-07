using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicontrollerSpawner : MonoBehaviour
{
	string HCName, path;
	public GameObject Player;

	void Start()
	{

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
}
