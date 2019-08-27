using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {

	public float maxZombieHealth = 50f;
	public float minZombieHealth = 0f;
	public float currentZombieHealth;
	
	private bool isDead;
	void Start () {
		currentZombieHealth = maxZombieHealth;
	}
	
	private void Update ()
	{
		//To ensure that the current car health doesn't increase than the maxium health 
		if (currentZombieHealth > maxZombieHealth) 
		{
			currentZombieHealth = maxZombieHealth;
		}
		if (currentZombieHealth < minZombieHealth) 
		{
			currentZombieHealth = minZombieHealth;
		}
		
	}
	public void DamageTaken (float damage)
	{
		if (isDead)
			return;

		currentZombieHealth -= damage;
		
		if (currentZombieHealth <= minZombieHealth && !isDead) 
		{
				Die ();
		}
	}
	
	private void Die ()
	{
		isDead = true;
		Destroy (gameObject, 1f);
	}
}