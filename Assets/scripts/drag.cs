using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
	float thedistance=8.0f;
	// Use this for initialization
	void OnMouseDrag()
	{
		Vector3 mousePosition=new Vector3(Input.mousePosition.x,Input.mousePosition.y,thedistance);
		Vector3 objPosition= Camera.main.ScreenToWorldPoint(mousePosition);

		transform.position=objPosition;
	}
}
