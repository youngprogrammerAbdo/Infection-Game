using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float damage;

	public void seek (float _damage)
	{
		 damage = _damage;
	}

	private void Update ()
	{
		Destroy (gameObject, 0.1f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			ZombieHealth zombieHealth = other.GetComponent<ZombieHealth>();
			if(zombieHealth != null)
			{
				zombieHealth.DamageTaken(damage);
				Destroy(gameObject);
				return;
			}
		}
	}
}
