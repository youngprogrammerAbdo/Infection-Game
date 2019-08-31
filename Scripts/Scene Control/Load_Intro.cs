using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Load_Intro : MonoBehaviour
{
	public float WaitTime;
	public int LevelNumber;
	// Start is called before the first frame update
	void Start()
    {;
		StartCoroutine(Wait());
    }

	IEnumerator Wait() {
		yield return new WaitForSeconds(WaitTime);
		SceneManager.LoadScene(LevelNumber);
	} 

}
