using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showtootherplayer : MonoBehaviour {
	public string cardlocname;
	private GameObject thelocobj;
	public bool isshowable=false;
	// Use this for initialization
	void Start () {
		cardlocname=gameObject.name+"loc";
		thelocobj=GameObject.Find(cardlocname);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		//make card visable but not pickable

		// return to location
		if(isshowable==true)
		{
		transform.position=thelocobj.transform.position;
		}
			//

	}
}
