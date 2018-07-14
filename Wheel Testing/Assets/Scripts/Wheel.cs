using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {

	public WheelCollider WheelCol;
	public GameObject WheelCylinder;
	public float WheelRot;
	public bool FrontWheel;
	// Use this for initialization
	void Awake () {
		WheelCol = GetComponent<WheelCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		WheelRot = WheelCol.steerAngle;
		WheelCylinder.transform.Rotate(0, WheelCol.rpm / 60 * 360 * -Time.deltaTime, 0);
		if (Input.GetKey(KeyCode.W))
		{
			WheelCol.motorTorque = 2000;
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			WheelCol.motorTorque = 0;
		}
		if (Input.GetKey(KeyCode.S))
		{
			WheelCol.brakeTorque = 400;
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			WheelCol.brakeTorque = 0;
		}
		if (FrontWheel)
		{
			WheelCylinder.transform.localEulerAngles = new Vector3(WheelCylinder.transform.localEulerAngles.x,
				WheelRot - WheelCylinder.transform.localEulerAngles.z + 90, WheelCylinder.transform.localEulerAngles.z);
			if (Input.GetKey(KeyCode.D))
			{
				WheelCol.steerAngle = Mathf.LerpAngle(WheelCol.steerAngle, 45, Time.deltaTime * 6);
			}

			if (Input.GetKey(KeyCode.A))
			{
				WheelCol.steerAngle = Mathf.LerpAngle(WheelCol.steerAngle, -45, Time.deltaTime * 6);
			}

			if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
			{
				WheelCol.steerAngle = Mathf.LerpAngle(WheelCol.steerAngle, 0f, Time.deltaTime * 10);
			}
		}

		/*
		else
		{
			WheelCol.steerAngle = Mathf.Clamp(WheelCol.steerAngle + 5 * Time.deltaTime, -50f, 0f);
		}

		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			if(WheelCol.steerAngle > 0)
			{
				WheelCol.steerAngle = Mathf.Clamp(WheelCol.steerAngle + 500 * -Time.deltaTime, 0f, 70f);
			}
			if (WheelCol.steerAngle < 0)
			{
				WheelCol.steerAngle = Mathf.Clamp(WheelCol.steerAngle + 500 * Time.deltaTime, -70f, 0f);
			}
		}

		if (Input.GetKey(KeyCode.D))
		{
			WheelCol.steerAngle = Mathf.Clamp( WheelCol.steerAngle + 150 * Time.deltaTime, -70, 70);
		}

		if (Input.GetKey(KeyCode.A))
		{
			WheelCol.steerAngle = Mathf.Clamp(WheelCol.steerAngle + 150 * -Time.deltaTime, -70, 70);
		}
*/
	}
}
