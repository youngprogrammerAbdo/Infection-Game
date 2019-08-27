using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float CarSpeed;
    public float MaxSpeed;
    public float WheelTurnSpeed;
    public float RotationWheelSpeed;
    public WheelCollider RightFront, LeftFront, RightBack, LeftBack;
    public Transform FrontWheel1,FrontWheel2, BackWheel1, BackWheel2;
    public AudioClip skidding;
    float RotateSpeed;
    float CurrentSpeed;
    AudioSource aduio;
    float ExtraSpeed,ExtraControl;
    int Currentcar;
    float turnvalue;
	private void Start()
    {
		Currentcar = CarSelection.ActiveCarNumber;
        ExtraSpeed = CarsPower.SpeedsforCars[Currentcar];
        ExtraControl = CarsPower.CarsControllers[Currentcar];
        aduio = GetComponent<AudioSource>();
       
    }

    //Car Acceleration
    void Acceleration() {
		CurrentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude;
		if (Input.GetKey(KeyCode.Space))
		{
			RightBack.motorTorque = 0;
			LeftBack.motorTorque = 0;
			RightBack.brakeTorque = 5;
			LeftBack.brakeTorque = 5;
		}
		else
		{
			if (CurrentSpeed < MaxSpeed)
			{

				RightBack.motorTorque = CarSpeed;
				LeftBack.motorTorque = CarSpeed;

			}
			else
			{
				RightBack.motorTorque = 0;
				LeftBack.motorTorque = 0;
			}
		}
		
	}

    //Turn Right And Left
    void Turn() {
		if (Options.ControlType== "Sensor") {
			turnvalue = Input.acceleration.x * 5;
		}
		turnvalue = Input.GetAxis("Horizontal");

		RightFront.steerAngle = (turnvalue * WheelTurnSpeed);
        LeftFront.steerAngle = (turnvalue * WheelTurnSpeed) ;
		//Wheel Rotate
		FrontWheel1.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, turnvalue * 30,0 ));
        FrontWheel2.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, turnvalue * 30, 0));
        BackWheel1.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, 0,0));
        BackWheel2.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, 0,0));
        
          RotateSpeed += RotationWheelSpeed*CurrentSpeed;
    }
    void PlaySounds() {
            
                aduio.pitch = 0.55f + (CurrentSpeed / MaxSpeed);
            
        }
    
    void Update()
    {
        Acceleration();
        Turn();
        PlaySounds();
    }
}
