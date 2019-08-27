using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentScore : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text =""+ PlayerPrefs.GetInt("score");
      //  Debug.Log("Current Car Number "+CarSelection.ActiveCarNumber+" Current Weapon Selection "+WeaponSelection.ActiveWeaponNumber);
    }
}
