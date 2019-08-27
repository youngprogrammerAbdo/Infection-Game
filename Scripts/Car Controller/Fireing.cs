using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireing : MonoBehaviour {

    public GameObject Bullet, Gun;
    public float FiringSpeed;
    float waitsTime;
    public float BulletSpeed;
    
    void TimeToFire(){

        waitsTime += Time.deltaTime;
        if (waitsTime >= FiringSpeed) {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject praticaleClone = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation) as GameObject;
                praticaleClone.GetComponent<Rigidbody>().AddForce(Gun.transform.forward * BulletSpeed);
            }
            waitsTime = 0;
        }
        

    }
    private void Update()
    {
        TimeToFire();
    }
}
