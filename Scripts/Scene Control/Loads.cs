using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loads : MonoBehaviour {

    public int LevelNumber;

    public void LoadScenes() {
        SceneManager.LoadScene(LevelNumber);
    }
}
