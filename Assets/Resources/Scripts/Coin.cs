using UnityEngine;

public class Coin : MonoBehaviour 
{
	void Update () {

		if (transform.position.x < -110)
			Destroy(gameObject);
		else
			transform.Translate(-Spawner.speed * Time.deltaTime, 0, 0, Space.World);

		transform.Rotate(0, 2f, 0, Space.World);
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player")
			Destroy(gameObject);

		other.transform.GetComponent<HeliController>().PickupCoin();
	}
}
