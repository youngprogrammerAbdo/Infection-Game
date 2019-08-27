using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLimitRotate : MonoBehaviour {

    public float minDegree=0;
    public float maxDegree = 180;
    // Update is called once per frame
    void Update () {

        Vector3 CurrentRotaion = transform.rotation.eulerAngles;
         CurrentRotaion.y = Mathf.Clamp(CurrentRotaion.y, 10, 180);
            
        transform.rotation = Quaternion.Euler(CurrentRotaion);

    }
}