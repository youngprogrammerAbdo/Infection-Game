using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {
    public float DieTime;
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, DieTime);		
	}
}
