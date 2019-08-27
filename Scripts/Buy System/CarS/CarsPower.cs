using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarsPower : MonoBehaviour {
    int CUrrentCarNumber;
   // public float[] Speed;
    //public float[] Health;
    //public float[] Control;
    public int[] CoinsToOpenCar;
    public Scrollbar scrolbarArmor, scrolbarHandiling, scrolbarWeight;
    public Text Score;
    public static int currentscore;
    public GameObject WeaponsMenuUI;
    public GameObject CarMenuUI;
    public GameObject Cars,Weapons;
    public static float[] SpeedsforCars,CarsControllers,CarsHealth;
    // Use this for initialization
     void Start()
    {
        // SpeedsforCars = Speed;
       //  CarsControllers = Control;
       //  CarsHealth=Health;
    }
    void Update()
    {
                CUrrentCarNumber = CarSelection.ActiveCarNumber;
                scrolbarArmor.size = PlayerPrefs.GetFloat("car" + (CUrrentCarNumber + 1) + "armor");
				scrolbarHandiling.size = PlayerPrefs.GetFloat("car" + (CUrrentCarNumber + 1) + "handiling");
				scrolbarWeight.size = PlayerPrefs.GetFloat("car" + (CUrrentCarNumber + 1) + "weight");
				Score.text = "" + CoinsToOpenCar[CUrrentCarNumber];
                currentscore = PlayerPrefs.GetInt("score");
		
	}
	/// <summary>
	/// Unlock Car if have coins more than required
	/// </summary>
	public void UnlockCar() {

        if (currentscore >= CoinsToOpenCar[CUrrentCarNumber]) {
            PlayerPrefs.SetInt("car" + (CUrrentCarNumber+1),1);
            currentscore = currentscore - CoinsToOpenCar[CUrrentCarNumber];
            PlayerPrefs.SetInt("score", currentscore);

            Debug.Log("Car Sold " + PlayerPrefs.GetInt("car" + (CUrrentCarNumber)));
        }
        }
    public void OpenWeaponsUI()
    {
        WeaponsMenuUI.SetActive(true);
        CarMenuUI.SetActive(false);
        Cars.SetActive(false);
        Weapons.SetActive(true);
    }
    }