using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour {

	private float damage;
	public float ExplosionRadius = 5f;
	public float explosionForce = 50f;
	public float maxLifeTime = 2f;

	private void Start ()
	{
		Destroy (gameObject, maxLifeTime);
	}
	public void seek (float _damage)
	{
		damage = _damage;
	}

	private void OnTriggerEnter(Collider other)
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, ExplosionRadius);

		for (int i = 0; i < colliders.Length; i++) {
			Rigidbody targetRigidbody = colliders [i].GetComponent<Rigidbody> ();

			if (targetRigidbody != null) {

				targetRigidbody.AddExplosionForce (explosionForce, transform.position, ExplosionRadius);
				ZombieHealth zombieHealth = other.GetComponent<ZombieHealth> ();
				if (zombieHealth != null) {
					zombieHealth.DamageTaken (damage);
					Destroy (gameObject);
					return;
				}

			}
		}
	}

}
