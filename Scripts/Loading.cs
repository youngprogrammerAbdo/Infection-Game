using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
	public int SceneNumber;
	public Image progressbar; 
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;
		StartCoroutine(LoadingScreen());
    }

	IEnumerator LoadingScreen() {
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneNumber);
		while (progressbar.fillAmount <= 1.5f)
		{
			progressbar.fillAmount = asyncLoad.progress;
			yield return new WaitForSeconds(0.2f);
		}
	}
}
