using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cards : MonoBehaviour {
	public List<GameObject> theCards = new List<GameObject>();//allcards at start
	public List<GameObject> _hand= new List<GameObject>();
	public List<GameObject> _hand2= new List<GameObject>();
	public List<GameObject> _deck = new List<GameObject>();

	public List<GameObject> _themurder = new List<GameObject>();
	public List<GameObject> _theweapons = new List<GameObject>();
	private List<GameObject> _therooms = new List<GameObject>();
	public List<GameObject> _thesuspects = new List<GameObject>();
	public List<GameObject> _guess = new List<GameObject>();
	public List<GameObject> _confirmedguess = new List<GameObject>();

	private GameObject[] setuparray;
	private GameObject[] sussetuparray;
	private GameObject[] weaponarray;
	private GameObject[] roomarray;
	private GameObject pickedobj;
	private GameObject pickedobjweapon;
	private GameObject pickedobjroom;
	public bool showmurdercards=true;
	public bool pickedcards=false;
	public Transform suspectloc;
	public Transform weaponloc;
	public Transform roomloc;
	private int randomnumber;
	public bool dealtofirstplayer=true;
	private int randomnumber2;
	public GameObject thefirstplayer;
	public GameObject thesecondplayer;
	private GameObject deactvateobj;
	public bool hidedone=false;
	public GameObject otherplayer;
	public GameObject thecurrentplayer;
	public GameObject box;
	public GameObject locationforbox;
	public GameObject[] cardholerpos;
	private GameObject thelocationforboxhome;

	// Use this for initialization
	void Start () {
		cardholerpos=GameObject.FindGameObjectsWithTag("cardpos");
		sussetuparray=GameObject.FindGameObjectsWithTag("suspect");
		for (int i=0;i<sussetuparray.Length; i++)
		{
			//GameObject g = GameObject.FindGameObjectWithTag("Card") as GameObject;
			_thesuspects.Add(sussetuparray[i]);
		}

		weaponarray=GameObject.FindGameObjectsWithTag("weapon");
		for (int i=0;i<weaponarray.Length; i++)
		{
			//GameObject g = GameObject.FindGameObjectWithTag("Card") as GameObject;
			_theweapons.Add(weaponarray[i]);
		}

		roomarray=GameObject.FindGameObjectsWithTag("room");
		for (int i=0;i<roomarray.Length; i++)
		{
			//GameObject g = GameObject.FindGameObjectWithTag("Card") as GameObject;
			_therooms.Add(roomarray[i]);
		}
		box=GameObject.Find("suggestionbox");
		locationforbox=GameObject.Find("suggestionboxloc");
		thelocationforboxhome=GameObject.Find("suggestionboxlochome");

	}
	
	// Update is called once per frame
	void Update () {
		bool checkplayer;
		checkplayer=GetComponent<gamemanager>().isplayeronesturn;
		if (checkplayer==true)
		{
			thecurrentplayer=GetComponent<gamemanager>().player1obj;

		}else
		{
			thecurrentplayer=GetComponent<gamemanager>().player2obj;
		}

		if (pickedcards==false)
		{
			randomlypick3forstart();
			pickedcards=true;
				
		}

		
	}

	void randomlypick3forstart()
	{
		pickedobj=_thesuspects[Random.Range(0,_thesuspects.Count-1)];

		_themurder.Add(pickedobj);
		_thesuspects.Remove(pickedobj);


		pickedobjweapon=_theweapons[Random.Range(0,_theweapons.Count-1)];
		_themurder.Add(pickedobjweapon);
		_theweapons.Remove(pickedobjweapon);	

		pickedobjroom=_therooms[Random.Range(0,_theweapons.Count-1)];
		_themurder.Add(pickedobjroom);
		_therooms.Remove(pickedobjroom);	



		addallcardstodeck();
		splitdecktoplayers();
	}

	public void hideplayer2hand()
	{
		showplayer1hand();
//		//_hand2[0].transform.position=weaponloc.position;
//		for (int i = 0; i < _hand2.Count;i++)
//		{
//			
//			_hand2[i].SetActive(false);
//		}
//		for (int i = 0; i < _hand.Count;i++)
//		{
//
//			_hand[i].SetActive(true);
//		}
	}
		public void showplayer1hand()
		{
			for (int i = 0; i < _hand.Count;i++)
			{
							
			_hand[i].GetComponent<acard>().cansee=true;
			}

			//hideplayer2hand
			for (int i = 0; i < _hand2.Count;i++)
			{

			_hand2[i].GetComponent<acard>().cansee=false;
			}
		}

	public void showplayer2hand()
	{
		for (int i = 0; i < _hand2.Count;i++)
		{

			_hand2[i].GetComponent<acard>().cansee=true;
		}

		//hideplayer2hand
		for (int i = 0; i < _hand.Count;i++)
		{

			_hand[i].GetComponent<acard>().cansee=false;
		}
	}




	

	public void hideplayer1hand()
	{
		showplayer2hand();
//		//_hand[0].transform.position=weaponloc.position;
//		for (int i = 0; i < _hand.Count;i++)
//		{_hand[i].SetActive(false);}
//
//		for (int i = 0; i < _hand2.Count;i++)
//		{_hand2[i].SetActive(true);}

	}



	void addallcardstodeck()
	{
		//addsuspects to deck
		for (int i=0;i<_thesuspects.Count; i++)
		{
			_deck.Add( _thesuspects[i]);
		}
		//add weapon to deck
		for (int i=0;i<_theweapons.Count; i++)
		{
			_deck.Add( _theweapons[i]);
		}
		//add rooms to deck
		for (int i=0;i<_therooms.Count; i++)
		{
			_deck.Add( _therooms[i]);
		}


		//_deck=_therooms+_theweapons+_thesuspects;
	}
	void splitdecktoplayers()
	{
		shuffledeck();
		halfdeck();

	}

	void shuffledeck()
	{
		
		for (int i = 0; i < _deck.Count; i++) {
			GameObject temp = _deck[i];
			int randomIndex = Random.Range(i, _deck.Count);
			_deck[i] = _deck[randomIndex];
			_deck[randomIndex] = temp;
		}


	}

	void halfdeck()
	{
		Debug.Log("the deck count :"+_deck.Count);
		//_hand2 = _deck.GetRange(0, _deck.Count/2);
		for (int i = 0; i < (_deck.Count/2);i++)
		{
			//_hand2.Add( _deck.GetRange(0, _deck.Count/2);
		
				_hand.Add( _deck[i]);
			//_deck.Remove( _deck[i]);
		}



		for (int i = _deck.Count/2; i < (_deck.Count);i++)
		{
			
			_hand2.Add( _deck[i]);
			//_hand2 = _deck.GetRange(0, _deck.Count);
			//_deck.Remove( _deck[i]);
		}

		_deck.Clear();
	}//halfdeck


	public void checkotherhands( )
	{
		
		if(thecurrentplayer!=null)
			{
				if (thecurrentplayer.name=="player1")
				{
					otherplayer=GameObject.Find("player2");
					Debug.Log("player2 is other");
				}
				else
				{otherplayer=GameObject.Find("player1");
					Debug.Log("player1 is other");
				}
			



				if(otherplayer.name=="player2")
				{


					for (int i=0;i<=_hand2.Count-1;i++)
					{
						if(_guess.Contains(_hand2[i]))
						{
						Debug.Log("other hand(player2) contains :"+_hand2[i].name);
							_confirmedguess.Add(_hand2[i]);
						}
						else{
						Debug.Log(""+_hand2[i].name+" not present in (player2) Hand!");
							}

					}//for
				//reset?? or Call show player confirmed guesses

				}
				else {//player2 guessing player1 hand


					if(otherplayer.name=="player1")
					{



					for (int i=0;i<=_hand.Count-1;i++)
					{
						if(_guess.Contains(_hand[i]))
						{
						Debug.Log("other hand(player1) contains :"+_hand[i].name);
							_confirmedguess.Add(_hand[i]);
						}
						else{
						Debug.Log(""+_hand[i].name+" not present in (player1)Hand!");
							}

					}//end for

				}//end ifplayer1isotherplayer
			}//endelse

				if(_confirmedguess.Count>0)
				{
					Debug.Log("show card(s) to other player");
					showcardstotherplayer();
				}

			}//end currentplayernottnull

	}//end class



	public void checkmurder()
	{
		int matchno=0;
		if (_guess.Count==3)
		{
			for (int i=0;i<=_guess.Count-1;i++)
					{
				if(_guess.Contains(_themurder[i]))
						{
							Debug.Log("the guess contains :"+_themurder[i].name);
					matchno++;
						}
				else{
					Debug.Log("the : "+_guess[i].name+" is not in the murder pile");}
				
					}

			if(matchno==3)
				{
					Debug.Log("The Murder solved : "+_themurder[0].name+","+_themurder[1].name+","+_themurder[2].name);
				
				}


		}
	}

//				for (int i=0;i<=_guess.Count;i++)
//				{if(_guess[i]==_themurder[0])
//					{
//						Debug.Log("guess "+i+"equals the firstmurdercard");
//					}
//					else{Debug.Log("guess "+i+"is not the firstmurdercard");}
//				}
//		}
	
	 
	void showcardstotherplayer()
	{
		//move box
		box.transform.position=locationforbox.transform.position;

		//move cards
		for (int i=0;i<=_confirmedguess.Count-1;i++)
			{
			_confirmedguess[i].transform.position=cardholerpos[i].transform.position;
			_confirmedguess[i].GetComponent<acard>().cansee=true;
			}
		//card select on click
	}

	public GameObject sentcardtoaddtohand(GameObject cardsentto)
	{
		checkplayer();
		//addto visable cards
		if (thecurrentplayer.name=="player1")
		{
			_hand.Add(cardsentto);
			showplayer1hand();
			cardsentto.GetComponent<acard>().cansee=true;

		}
		else{
			_hand.Add(cardsentto);
			showplayer2hand();
			cardsentto.GetComponent<acard>().cansee=true;
			}
		clearguessandconfirmed();//CHECK
		movecardboxhome();

		//send other cards back
		for (int i=0;i<=_confirmedguess.Count-1;i++)
		{
			GameObject temploc=_confirmedguess[i].GetComponent<acard>().thelocobj;
			_confirmedguess[i].transform.position=temploc.transform.position;
		_confirmedguess[i].GetComponent<acard>().cansee=false;//rehide cards
		}
		return cardsentto;

	}
	void checkplayer()
	{
		if(thecurrentplayer!=null)
		{
			if (thecurrentplayer.name=="player1")
			{
				otherplayer=GameObject.Find("player2");
				Debug.Log("player2 is other");
			}
			else
			{otherplayer=GameObject.Find("player1");
				Debug.Log("player1 is other");
			}
		}
	}

	int D6(int value)
	{
		value=Random.Range(1,6);
		return value;
	}
	void clearguessandconfirmed()
	{
		_guess.Clear();
		_confirmedguess.Clear();
	}

	void movecardboxhome()
	{
		box.transform.position=thelocationforboxhome.transform.position;
	}

}
