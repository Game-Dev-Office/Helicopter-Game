using UnityEngine;

public class House : MonoBehaviour
{
	void Update()
	{

		if (transform.position.x < -110)
			Destroy(gameObject);
		else
			transform.Translate(-Spawner.speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		other.transform.gameObject.GetComponent<HeliController>().Explode();
	}
}

