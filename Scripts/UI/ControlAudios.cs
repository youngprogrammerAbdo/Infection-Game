using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudios : MonoBehaviour
{
	float CurrentAudioVolume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		CurrentAudioVolume = PlayerPrefs.GetFloat("optionsvalue");
		this.GetComponent<AudioSource>().volume = CurrentAudioVolume;
	}
}

