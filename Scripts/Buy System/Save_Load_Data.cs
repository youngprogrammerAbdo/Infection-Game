using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Load_Data : MonoBehaviour {

	void Start() {
		InitialData();
		PlayerPrefs.SetInt("score", 512000);
	}

	//Initial Data
	void InitialData() {

		SaveData("score", 0);
		CarSaves();

		SaveDatafloat("optionsvalue", 0);
		SaveControlTypeOption("ControlType", "Touch");
	}

	void CarSaves() {
		SaveData("car1", 1);
		SaveData("car2", 0);
		SaveData("car3", 0);
		SaveData("car4", 0);
		SaveData("car5", 0);
		SaveData("car6", 0);
		
		SaveDatafloat("car1armor", 0.1f);
		SaveDatafloat("car1handiling", 0.1f);
		SaveDatafloat("car1weight", 0.1f);

		SaveDatafloat("car2armor", 0.1f);
		SaveDatafloat("car2handiling", 0.1f);
		SaveDatafloat("car2weight", 0.1f);

		SaveDatafloat("car3armor", 0.1f);
		SaveDatafloat("car3handiling", 0.1f);
		SaveDatafloat("car3weight", 0.1f);

		SaveDatafloat("car4armor", 0.1f);
		SaveDatafloat("car4handiling", 0.1f);
		SaveDatafloat("car4weight", 0.1f);

		SaveDatafloat("car5armor", 0.1f);
		SaveDatafloat("car5handiling", 0.1f);
		SaveDatafloat("car5weight", 0.1f);

		SaveDatafloat("car6armor", 0.1f);
		SaveDatafloat("car6handiling", 0.1f);
		SaveDatafloat("car6weight", 0.1f);

	}

	void SaveControlTypeOption(string dataname,string value) {
		if (!PlayerPrefs.HasKey(dataname))
		{
			Debug.Log("No data");
			PlayerPrefs.SetString(dataname, value);
		}
	}
	void SaveData(string dataname, int value)
    {
        if (!PlayerPrefs.HasKey(dataname))
        {
            Debug.Log("No data");
            PlayerPrefs.SetInt(dataname, value);
        }
    }
        void SaveDatafloat(string dataname, float value)
        {
            if (!PlayerPrefs.HasKey(dataname))
            {
                Debug.Log("No data");
                PlayerPrefs.SetFloat(dataname, value);
            }

        }
    }