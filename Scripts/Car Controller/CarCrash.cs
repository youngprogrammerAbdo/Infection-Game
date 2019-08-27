using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour {

    public GameObject HitObject;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Zombie") {
            foreach (ContactPoint contact in collision.contacts) {
                Debug.Log(" X "+ contact.point.x +" Y " + contact.point.x + " Z "+contact.point.z);
              GameObject Hit = Instantiate(HitObject,contact.point,Quaternion.identity) as GameObject;
                Hit.transform.SetParent(transform);
                
            }
        }
    }
}
