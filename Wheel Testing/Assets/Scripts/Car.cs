using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody rg;
	public GameObject centMass;
	// Use this for initialization
	void Awake () {
		rg = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		rg.centerOfMass = centMass.transform.localPosition;
	}
}
