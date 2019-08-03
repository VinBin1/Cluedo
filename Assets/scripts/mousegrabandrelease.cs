using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousegrabandrelease : MonoBehaviour {
	Vector3 offset;
	public Camera thecamera;
	//public Texture2D cursorTexture;
	//public CursorMode cursorMode = CursorMode.Auto;
	//public Vector2 hotSpot = Vector2.zero;
	private RaycastHit rayHit;
	private GameObject collideObj;
	private float thedistance;
	private Vector3 posObj;
	private bool haveobj;
	// Use this for initialization
	void Start () {
		//Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {


		//Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		if (Input.GetMouseButton(0))
		{
			var ray = thecamera.ScreenPointToRay(Input.mousePosition); 

			var hit=Physics.Raycast(ray.origin,ray.direction, out rayHit);

			if (hit&&!haveobj)
			{
				Debug.Log("hit the "+rayHit.collider.gameObject.name);
				collideObj=rayHit.collider.gameObject;
				thedistance=rayHit.distance;
				Debug.Log("hit the "+collideObj.name);
								
			}
			haveobj=true;
			posObj=ray.origin+thedistance*ray.direction;
			collideObj.transform.localPosition=new Vector3(posObj.x,collideObj.transform.position.z,1);
			Debug.Log("is at x:"+posObj.x+" Y:"+posObj.y+"z:"+collideObj.transform.position.z);

		}
		else{haveobj=false;}



	}
}
