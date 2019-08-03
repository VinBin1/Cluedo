using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enteredroom : MonoBehaviour {
	private GameObject thesuggestionbox;
	private GameObject thesuggestionboxloc;
	private GameObject thecardsobj;
	private GameObject thecardthatmatchesthisroom;
	public string thegameobejectsnametochop;
	public int gotthree=0;
	public GameObject theplayerthattriggers;
	public GameObject thecardthatmatchesthisweapon;
	private GameObject theweapon;
	private GameObject thesuspect;
	private string weaponsnametochop;
	private string suspectsnametochop;


	// Use this for initialization
	void Awake () {
		thesuggestionbox=GameObject.Find("suggestionbox");
		thesuggestionboxloc=GameObject.Find("suggestionboxloc");
		thecardsobj=GameObject.Find("aaascriptobject");//later static
		thegameobejectsnametochop=gameObject.name;
		thegameobejectsnametochop = thegameobejectsnametochop.Remove(thegameobejectsnametochop.Length - 3);
		thecardthatmatchesthisroom=GameObject.Find(thegameobejectsnametochop);
	}
	
	// Update is called once per frame
	void Update () {
	



	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag=="Player")
		{
		Debug.Log(""+other.gameObject.name+" entered the " +gameObject.name);

			thesuggestionbox.transform.position=thesuggestionboxloc.transform.position;
			other.gameObject.GetComponent<playerscript>().cansuggest=true;

			thecardsobj.GetComponent<cards>()._guess.Add(thecardthatmatchesthisroom);
			gotthree++;
		
			theplayerthattriggers=other.gameObject;

		}

		if (other.gameObject.tag=="asuspect")
		{
			Debug.Log("suspect " +other.gameObject.name);
			suspectsnametochop=other.gameObject.name;
			suspectsnametochop=suspectsnametochop.Remove(suspectsnametochop.Length - 3);
			thesuspect=GameObject.Find(suspectsnametochop);
			thecardsobj.GetComponent<cards>()._guess.Add(thesuspect);

			gotthree++;
		}

		if (other.gameObject.tag=="aweapon")
		{
			weaponsnametochop=other.gameObject.name;
			weaponsnametochop=weaponsnametochop.Remove(weaponsnametochop.Length - 3);
			thecardthatmatchesthisweapon=GameObject.Find(weaponsnametochop);
			Debug.Log("Weapon " +other.gameObject.name);
			//checkif in array
			if(thecardsobj.GetComponent<cards>()._guess.Contains(thecardthatmatchesthisweapon))
			{}
			else{
			thecardsobj.GetComponent<cards>()._guess.Add(thecardthatmatchesthisweapon);


			gotthree++;
			}
		}

		if (gotthree==3)
		{
					thecardsobj.GetComponent<cards>().checkotherhands();
			//thecardsobj.GetComponent<cards>().checkmurder();
			gotthree=0;
		}


	}//end trig
}
