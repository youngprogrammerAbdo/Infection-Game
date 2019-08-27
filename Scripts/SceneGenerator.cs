using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour {
	public GameObject[] Groups;
	public static float newPosition;
	//1288cm citys length
	private void Awake()
	{
		for (int i = 0; i < 2; i++) {
		int	RandChooseGroup = Random.Range (0, Groups.Length);

			Instantiate (Groups [RandChooseGroup], new Vector3 (0f, 0f, newPosition), Quaternion.identity);
			newPosition = newPosition + 1288f;
		}
		}

}
