
using UnityEngine;

public class DestroyByFall : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Destroyer")
			return;

		Destroy (other.gameObject);
	}
}
