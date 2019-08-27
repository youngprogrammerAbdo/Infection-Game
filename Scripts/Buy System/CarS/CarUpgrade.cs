using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarUpgrade : MonoBehaviour {

    public int MoneyToUpgrade;
    int CurrentCar;
    float CurrentArmor;
	int CurrentScores;
    public GameObject NeededCointUI;
    int sumScore;
    float NewPower, NewSpeed, NewBullets;
	 string power,speed, bullets, str;
    private void Update()
    {
        CurrentCar = CarSelection.ActiveCarNumber;
        CurrentScores = CarsPower.currentscore;
        //Debug.Log("Car No "+CarSelection.ActiveCarNumber);
    }
    public void ArmorUpgrade() {
	    Upgrade("armor");
    }
    public void HandilingUpgrade()
    {
        Upgrade("handiling");
    }
    public void WeightUpgrade()
    {
        Upgrade("weight");
    }

    void Upgrade(string type)
    {
		if (PlayerPrefs.GetInt("car" + (CurrentCar+1)) != 0)
		{
			Debug.Log("Increase Upgrade" + PlayerPrefs.GetInt("car" + CurrentCar));
			sumScore = CurrentScores - MoneyToUpgrade;
			power = "car" + (CurrentCar + 1) + type;
			CurrentArmor = PlayerPrefs.GetFloat(power);
			NewPower = CurrentArmor + 0.1f;
			str = "car" + (CurrentCar + 1) + type;
			if (CurrentScores >= MoneyToUpgrade && CurrentArmor <= 1)
			{
				PlayerPrefs.SetInt("score", sumScore);
				PlayerPrefs.SetFloat(str, NewPower);
			}
			else
			{
				NeededCointUI.SetActive(true);
			}
			//Debug.Log(power+"  "+NewPower);
		}
    }

    public void CloseNeedCoinUI() {
        NeededCointUI.SetActive(false);
    }
}