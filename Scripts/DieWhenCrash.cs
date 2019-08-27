using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenCrash : MonoBehaviour {
	public Animator anim;

	 void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();
			otherRB.isKinematic = false;
			otherRB.AddForce(-transform.forward * 50000f);
			other.GetComponent<ZombieMovement>().enabled = false;
			other.GetComponent<ZombieHealth>().DamageTaken(9999f);

		}
	}
}
