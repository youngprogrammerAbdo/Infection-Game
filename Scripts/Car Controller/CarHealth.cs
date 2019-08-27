using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour {
    public float maxCarHealth = 200f;
    public float minCarHealth = 0;
    public float obteclesDamageToCar = 5f;
    public static float currentCarHealth;

    private bool dead;
    void Start() {
        currentCarHealth = maxCarHealth;
    }

    private void Update()
    {
        //To ensure that the current car health doesn't increase than the maxium health 
        if (currentCarHealth > maxCarHealth)
        {
            currentCarHealth = maxCarHealth;
        }
        if (currentCarHealth < minCarHealth)
        {
            currentCarHealth = minCarHealth;
        }

    }
    public void DamageTaken(float damage)
    {
        currentCarHealth -= damage;

        if (currentCarHealth <= minCarHealth && !dead)
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;
        //how the car die
    }
    private void OntTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obtecles")
        {
            DamageTaken(obteclesDamageToCar);
        }
    }
    private void OntTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Obtecles")
        {
            return;
        }
    }
}
