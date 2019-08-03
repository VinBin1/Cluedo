using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour {

	public float thrust=1.0f;
	public Rigidbody rb;
	public bool rollnow=false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if(rollnow==true)
		{
			rb.AddForce(transform.up * thrust);
			transform.rotation = Random.rotation;

			rollnow=false;
		}
		
	}
}
