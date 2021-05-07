using UnityEngine;

public class Airplane : MonoBehaviour 
{
	void Update ()
	{
		if (transform.position.x < -110)
			Destroy(gameObject);
		else
			transform.Translate(-Spawner.speed * 2 * Time.deltaTime, 0, 0, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			Destroy(gameObject);

		other.transform.gameObject.GetComponent<HeliController>().Explode();
	}
}
