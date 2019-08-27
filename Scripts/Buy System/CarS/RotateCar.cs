using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCar : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        var mouserotate = Input.GetAxis("Mouse X") * 4;
        transform.Rotate(0, mouserotate, 0);
    }
}
