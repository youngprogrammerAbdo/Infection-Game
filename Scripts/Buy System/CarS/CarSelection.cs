using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour {

    public GameObject[] Cars;
    public static int ActiveCarNumber;
    public GameObject UnlockCarsUI;
    public GameObject UnlockCarsButton;
    public GameObject NextSelectWeaponsButton;
    // Update is called once per frame
    void Update () {
        for (int x=0;x<Cars.Length;x++) {
            if (x == ActiveCarNumber)
            {
                Cars[x].SetActive(true);
                if (PlayerPrefs.GetInt("car" + (x + 1)) == 0)
                {
                    UnlockCarsUI.SetActive(true);
                    UnlockCarsButton.SetActive(true);
                    NextSelectWeaponsButton.SetActive(false);
                }
                else
                {
                    UnlockCarsUI.SetActive(false);
                    UnlockCarsButton.SetActive(false);
                    NextSelectWeaponsButton.SetActive(true);
                }
            }

            else
            {
                
            Cars[x].SetActive(false);

            }
            
        }
    }

}