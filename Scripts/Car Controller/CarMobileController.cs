using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMobileController : MonoBehaviour
{
	public float CarSpeed;
	public float MaxSpeed;
	public float WheelTurnSpeed;
	public float RotationWheelSpeed;
	public WheelCollider RightFront, LeftFront, RightBack, LeftBack;
	public Transform FrontWheel1, FrontWheel2, BackWheel1, BackWheel2;
	public AudioClip skidding;
	public GUISkin skin;
	float RotateSpeed;
	float CurrentSpeed;

	//GUI Variables
	Rect  RecRight, RecLeft;
	public Texture2D Right, Left;
	//Car Variable 
	AudioSource aduio;
	float ExtraSpeed, ExtraControl;
	int Currentcar;
	float turnvalue;


	void OnGUI() {
		GUI.skin = skin;
		RecLeft = new Rect(Screen.width * 0.08f,Screen.height * 0.55f,Screen.width*0.1f,Screen.height*0.2f);
		RecRight = new Rect(Screen.width * 0.8f, Screen.height * 0.55f, Screen.width * 0.1f, Screen.height * 0.2f);
		if (Options.ControlType == "Touch")
		{

			GUI.Button(RecRight, Right);
			GUI.Button(RecLeft, Left);
		}
	}
	// Start is called before the first frame update
	void Start()
    {
		Currentcar = CarSelection.ActiveCarNumber;
		ExtraSpeed = CarsPower.SpeedsforCars[Currentcar];
		ExtraControl = CarsPower.CarsControllers[Currentcar];
		aduio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
			MultipeTouches();
			Acceleration();
			Turn();
			PlaySounds();
		
	}

	void MultipeTouches()

	{

		foreach (Touch t in Input.touches)
		{
			Vector2 vec = t.position;
			vec.y = Screen.height - vec.y;
			
			if (RecLeft.Contains(vec))
			{
				turnvalue = -0.3f;
			}
			else if (RecRight.Contains(vec))
			{
				
				turnvalue = 0.3f
					;
			}
			else {
				turnvalue = 0;
			}
		}
	}

	//Car Acceleration
	void Acceleration()
	{
		CurrentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude;
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
	void Turn()
	{
		if (Options.ControlType == "Sensor")
		{
			turnvalue = Input.acceleration.x * 5;
		}
		//turnvalue = Input.GetAxis("Horizontal");

		RightFront.steerAngle = (turnvalue * WheelTurnSpeed);
		LeftFront.steerAngle = (turnvalue * WheelTurnSpeed);
		//Wheel Rotate
		FrontWheel1.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, turnvalue * 30, 0));
		FrontWheel2.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, turnvalue * 30, 0));
		BackWheel1.transform.rotation = Quaternion.Euler(new Vector3(RotateSpeed, 0, 0));
		BackWheel2.transform.localRotation = Quaternion.Euler(new Vector3(RotateSpeed, 0, 0));

		RotateSpeed += RotationWheelSpeed * CurrentSpeed;
	}
	void PlaySounds()
	{

		aduio.pitch = 0.55f + (CurrentSpeed / MaxSpeed);

	}

}