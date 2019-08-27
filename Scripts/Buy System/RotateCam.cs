using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour {

    public float Speed;
    public Camera cam;
    // Update is called once per frame
	void Update () {
        var mouserotate = Input.GetAxis("Mouse X")*4;
        transform.Rotate(0, mouserotate + (Speed * Time.deltaTime), 0, Space.World);
        

    }
}
