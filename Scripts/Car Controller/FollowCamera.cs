using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform target;
    public float smooth = 0.3F;
    public float distance = 5.0F;
    private float yVelocity = 0F;
    public float Hight;
    public GameObject[] Cars;

    void Start()
    {
                target = Cars[CarSelection.ActiveCarNumber].transform;
                Debug.Log("Target "+target +"Car Number " + CarSelection.ActiveCarNumber);
            
        
    }
    void FixedUpdate()
    {
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
        Vector3 position = target.position;
        position += Quaternion.Euler(Hight, yAngle, 0) * new Vector3(0, 0, -distance);
        transform.position = position;
        transform.LookAt(target);
    }
}
