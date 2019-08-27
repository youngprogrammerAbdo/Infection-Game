
using UnityEngine;

public class ZombieCatch : MonoBehaviour {

	public Animator anim;
	public Rigidbody zombie_rigidbody;
    public float zombieDamageToCar = 10f;
    ZombieMovement zombieMovement;
    CarHealth carHealth;

    private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "CatchPoint") 
		{
            GetComponentInParent<ZombieMovement>().enabled = false;
			transform.parent.transform.parent.GetComponent<CapsuleCollider>().isTrigger = true;
			gameObject.transform.parent.transform.parent.transform.SetParent(other.gameObject.transform);
			zombie_rigidbody.useGravity = false;
			zombie_rigidbody.velocity = Vector3.zero;
			zombie_rigidbody.isKinematic = true;
			anim.SetFloat("Speed", 0);
            anim.SetBool("Hang", true);
            if(carHealth == null)
            {
                carHealth = other.GetComponentInParent<CarHealth>();
            }
            carHealth.DamageTaken(zombieDamageToCar);
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            if (carHealth == null)
            {
                carHealth = other.GetComponentInParent<CarHealth>();
            }
            carHealth.DamageTaken(zombieDamageToCar);
        }
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            return;
        }
    }
}
