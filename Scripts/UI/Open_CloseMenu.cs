using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_CloseMenu : MonoBehaviour
{
	public GameObject Topen, ToClose;
	public void Open() {

		Topen.SetActive(true);
		Time.timeScale = 1;
	}
	public void Close() {
		ToClose.SetActive(false);
		Time.timeScale = 0;
	}

	public void OpenOptionsInGame() {
		Time.timeScale = 0;
		Topen.SetActive(true);
	}
	public void CloseOptionsInGame()
	{
		Time.timeScale = 1;
		ToClose.SetActive(false);
	}
}
