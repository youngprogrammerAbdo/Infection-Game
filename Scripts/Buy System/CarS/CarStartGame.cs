using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStartGame : MonoBehaviour
{
	public GameObject[] Cars;
	int CurrentCar;
    // Start is called before the first frame update
    void Start()
    {
		CurrentCar = CarSelection.ActiveCarNumber;
		Cars[CarSelection.ActiveCarNumber].SetActive(true);
    }
	
}
