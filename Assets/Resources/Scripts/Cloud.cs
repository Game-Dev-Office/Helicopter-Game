using UnityEngine;

public class Cloud : MonoBehaviour
{
	void Update()
	{
		if (transform.position.x < -300)
			Destroy(gameObject);
		else
			transform.Translate(-Spawner.speed * Time.deltaTime, 0, 0, Space.World);
	}
}
