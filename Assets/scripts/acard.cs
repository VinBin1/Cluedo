using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acard : MonoBehaviour {
	private GameObject cardgameobject;
	private string cardname;
	private bool faceup=false;
	private Renderer therenderer;
	public bool cansee=false;

	public string cardlocname;
	public GameObject thelocobj;
	public bool isshowable=false;
	private GameObject thecardscobj;

	// Use this for initialization
	void Start () {

		therenderer = GetComponentInChildren<Renderer>();
		cardlocname=gameObject.name+"loc";
		thelocobj=GameObject.Find(cardlocname);
		thecardscobj=GameObject.Find("aaascriptobject");
	}
	
	// Update is called once per frame
	void Update () {
		if(cansee==true)
		{
				therenderer.enabled=true;
			}
				else{therenderer.enabled=false;}


	}
	void OnMouseDown()
	{
		//make card visable but not pickable

		// return to location
//		if(isshowable==true)
//		{
			transform.position=thelocobj.transform.position;
			thecardscobj.GetComponent<cards>().sentcardtoaddtohand(this.gameObject);
//		}	
	}//onmousedown
}
