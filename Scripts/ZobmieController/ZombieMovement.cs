using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {
	[Header("FindTarget")]
	public Transform target;
	[Range(25, 150)]public float ZombirRange = 25f;

	[Header("Movement")]
	[SerializeField]private float moveSpeed = 5f;
	[SerializeField]private float turnSpeed = 120f;
	public float stopDistance = 0;
//	[Range(10,15)]public float waitTime = 10f; 
//	public float walkSpeed = 5f;

	Animator anim;
//	Rigidbody rb;

	void Start () {
		anim = GetComponentInChildren<Animator> ();
	//	rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		else 
		{
			float distance = Vector3.Distance (transform.position, target.position);
			if (distance <= ZombirRange) 
			{
				Move (distance);
			}
			else 
			{
			//	StartCoroutine(MoveRandomly());
			}
		}

	}
	private void Move (float distance)
	{

		if (distance >= stopDistance) {
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
			anim.SetFloat ("Speed", 1);
		}
		else 
		{
			anim.SetFloat ("Speed", 0);
			transform.position = Vector3.zero;

		}
		Vector3 directionToTarget = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (directionToTarget);
		Vector3 rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}
	/*
	private IEnumerator MoveRandomly()
	{
		float aroundX = Random.Range (-2, 2);
		float aroundZ = Random.Range (-2, 2);
		Vector3 movment = new Vector3 (aroundX, 0f, aroundZ) * Time.deltaTime * walkSpeed;
		yield return new WaitForSeconds (waitTime);
		rb.MovePosition (movment);
	}*/
	private void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, ZombirRange);
	}
}
