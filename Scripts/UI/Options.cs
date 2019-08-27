

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
	public Slider sounds;
	public static float SoundsValue;
	public static string ControlType ="";
	public Button Touch, Sensor;
	// Update is called once per frame
	void Start() {

		sounds.value = PlayerPrefs.GetFloat("optionsvalue");

	}

	void Update()
    {
		SoundsOptions();
		if (PlayerPrefs.GetString("ControlType") == "Touch")
		{
			Touch.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
			Sensor.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
		}
		else {
			Touch.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
			Sensor.GetComponent<Image>().color = new Color(255, 255, 255, .6f);
		}
	}

	void SoundsOptions() {
		PlayerPrefs.SetFloat("optionsvalue", sounds.value);
		SoundsValue = PlayerPrefs.GetFloat("optionsvalue");
	}

	public void TouchControl() {
		ControlType = "Touch";
		PlayerPrefs.SetString("ControlType", ControlType);
	}

	public void SensorControl()
	{
		ControlType = "Sensor";
		PlayerPrefs.SetString("ControlType", ControlType);
	}
}
