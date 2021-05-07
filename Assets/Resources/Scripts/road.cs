using UnityEngine;

public class road : MonoBehaviour
{
	void Update()
	{
		if (transform.position.x < -310)
			Destroy(gameObject);
		else
			transform.Translate(-Spawner.speed * Time.deltaTime, 0, 0, Space.World);
	}
}
