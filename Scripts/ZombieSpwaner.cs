using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpwaner : MonoBehaviour {
	public GameObject Zombie;
	public int NumberOfZombies = 5;
	public float waitTime = 45f;

	private void Start()
	{
		InvokeRepeating ("Spwan", 0f, waitTime);
	}
	private void Spwan()
	{
		for (int i = 0; i <= NumberOfZombies; i++)
		{
			if (i >= NumberOfZombies)
				return;

			float x = Random.Range (10, 70);
			float z = Random.Range (50, 100);
			Instantiate (Zombie, new Vector3 (transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity);

		}
	}
}
