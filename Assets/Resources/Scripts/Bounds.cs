using UnityEngine;

public class Bounds : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		float speed = other.transform.parent.gameObject.GetComponent<HeliController>().speed;
		
		other.transform.parent.gameObject.transform.Translate(-other.transform.parent.gameObject.GetComponent<Rigidbody>().velocity / speed);
		other.transform.parent.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}
}
