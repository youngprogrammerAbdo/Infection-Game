using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {
	public GameObject partSys;
	private List<ParticleSystem> allContactParticles;
	private float newPos;
	[Header("City")] 
	private int RandChooseGroup;
	public GameObject[] Groups;

	private void Start ()
	{
		newPos = SceneGenerator.newPosition;
	}

	private void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
			return;

		foreach (ContactPoint contact in collision.contacts) {

			GameObject sparks = Instantiate (partSys, contact.point, Quaternion.LookRotation (contact.normal)) as GameObject;
			sparks.GetComponent<ParticleSystem>().Play();
			Destroy (sparks, 0.5f);
		}
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "BuildPoint")
		{
			Instanitate();
		}
	}
	
	private void Instanitate ()
	{
		Instantiate (Groups[RandChooseGroup], new Vector3(0f, 0f, newPos), Quaternion.identity);
		newPos = newPos + 1288f; 
	}
	private void Update ()
	{
		RandChooseGroup = Random.Range (0, Groups.Length);
	}

}
