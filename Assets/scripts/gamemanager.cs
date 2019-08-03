using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour {
	public bool isplayeronesturn=true;
		public GameObject player1obj;
	public GameObject player2obj;



	// Use this for initialization
	void Start () {
		player1obj.GetComponent<playerscript>().hasturn=true;
	}
	
	// Update is called once per frame
	void Update () {

		if (player1obj.GetComponent<playerscript>().hasmoved==true)
		{
			//endplayer1turn, Start player2 turn
			player1obj.GetComponent<playerscript>().hasturn=false;
			player1obj.GetComponent<playerscript>().hasmoved=false;


			player2obj.GetComponent<playerscript>().hasturn=true;
		}

		if (player2obj.GetComponent<playerscript>().hasmoved==true)
		{
			player2obj.GetComponent<playerscript>().hasturn=false;
			player2obj.GetComponent<playerscript>().hasmoved=false;
			player1obj.GetComponent<playerscript>().hasturn=true;
		}



	}

				///Functions/methods





}
