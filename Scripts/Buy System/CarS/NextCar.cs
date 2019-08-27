using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCar : MonoBehaviour {

    public void Next() {
        
        CarSelection.ActiveCarNumber++;
        if (CarSelection.ActiveCarNumber > 5)
            CarSelection.ActiveCarNumber = 0;
	}
	public void Prev() {
		CarSelection.ActiveCarNumber--;
		if (CarSelection.ActiveCarNumber < 0)
			CarSelection.ActiveCarNumber = 5;

	}
}
