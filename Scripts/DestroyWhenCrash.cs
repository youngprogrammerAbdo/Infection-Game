using System.Collections;
using UnityEngine;

public class DestroyWhenCrash : MonoBehaviour {
	private float OnOffTime = .25f;
    public float DamageToCarWhenHitObtecles = 5f;
	private void  OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();
			otherRB.isKinematic = false;
			otherRB.AddForce(-transform.forward * 50000f);
			other.GetComponent<ZombieMovement>().enabled = false;
			other.GetComponent<ZombieHealth>().DamageTaken(9999f);
			
		}
		if (other.gameObject.tag == "Obtecles") 
		{
			GetComponentInParent<CarHealth>().DamageTaken(2f);
			other.isTrigger = true;
			StartCoroutine(DestroyObtcles(other.gameObject));
		}
	}

	private IEnumerator DestroyObtcles(GameObject otherGameObject)
	{
		otherGameObject.SetActive (false);
		yield return new WaitForSeconds (OnOffTime);
		otherGameObject.SetActive (true);
		yield return new WaitForSeconds (OnOffTime);
		otherGameObject.SetActive (false);
		yield return new WaitForSeconds (OnOffTime);
		otherGameObject.SetActive (true);
		yield return new WaitForSeconds (OnOffTime);
		otherGameObject.SetActive (false);

		
		
	}
}
