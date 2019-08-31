using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCar : MonoBehaviour {

	public GameObject VFXFire;
	public Transform VFXFirePos;
	GameObject Fire;
	public void Next() {
		VFXFire.SetActive(true);
		Fire=Instantiate(VFXFire,VFXFirePos.position, VFXFirePos.transform.rotation) as GameObject;
		Destroy(Fire, 2);
		CarSelection.ActiveCarNumber++;
        if (CarSelection.ActiveCarNumber > 5)
            CarSelection.ActiveCarNumber = 0;
	}
	public void Prev() {
		VFXFire.SetActive(true);
		Fire = Instantiate(VFXFire, VFXFirePos.position, VFXFirePos.transform.rotation) as GameObject;
		Destroy(Fire,2);
		CarSelection.ActiveCarNumber--;
		if (CarSelection.ActiveCarNumber < 0)
			CarSelection.ActiveCarNumber = 5;

	}
}
