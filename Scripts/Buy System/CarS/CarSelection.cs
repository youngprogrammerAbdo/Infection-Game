using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour {

    public GameObject[] Cars;
    public static int ActiveCarNumber;
    public GameObject UnlockCarsUI;
    public GameObject UnlockCarsButton;
    public GameObject NextButton;
	void Start()
	{
		StartCoroutine(Wits());
	}
	IEnumerator Wits() {
		
		while (true)
		{
			for (int x = 0; x < Cars.Length; x++)
			{
				if (x == ActiveCarNumber)
				{
					if(x>0)
					Cars[x-1].SetActive(false);
					yield return new WaitForSeconds(0.5f);
					Cars[x].SetActive(true);
					if (PlayerPrefs.GetInt("car" + (x + 1)) == 0)
					{
						UnlockCarsUI.SetActive(true);
						UnlockCarsButton.SetActive(true);
						NextButton.SetActive(false);
					}
					else
					{
						UnlockCarsUI.SetActive(false);
						UnlockCarsButton.SetActive(false);
						NextButton.SetActive(true);
					}
				}

				else
				{

					Cars[x].SetActive(false);

				}

			}
		}
	}
}