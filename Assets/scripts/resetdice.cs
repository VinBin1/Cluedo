using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetdice : MonoBehaviour {

	[SerializeField]
	int minxvalue;
	Vector3 currentpos;

	[SerializeField]
	Transform restartpos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentpos=transform.position;
		if(currentpos.y<minxvalue)
		{
			resetthedice();
		}
			
	}
	void resetthedice()
	{
		transform.position=restartpos.position;
	}
}
