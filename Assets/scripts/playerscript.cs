using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerscript : MonoBehaviour {
	public GameObject markerObject;
	private GameObject thegroundPlane;
	public KeyCode upkey;
	public KeyCode downkey;
	public KeyCode rightkey;
	public KeyCode leftkey;
	public KeyCode spacekey;
	public float movedistance=0.3f;
	public Vector3 currentpos;
	public bool hasturn;
	public bool hasmoved=false;
	public GameObject showturntext;
	public Text showmovedremainingtxt;
	//public Plane thegroundPlane;
	public int movesperturn;
	public bool hasfinishedmoving=false;
	public bool hasrolled=false;
	public bool showingtext=false;
	public GameObject thedie;
	public GameObject thecardsobj;
	public bool showthecards=true;
	public bool cansuggest;
	public bool turnended=false;
	public Vector3 playertomousedir;
	public float thedistance=0.1f;
	public Vector3 mousePosition;
	public Vector3 clickpos;
	public float xpos;
	public float ypos;
	public float thewidth, theheight;




	// Use this for initialization
	void Start () {
		thewidth=Screen.width; 
		theheight=Screen.height;
		//thegroundPlane=GameObject.Find("mouseplane");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (hasturn==true)
		{
			if(showthecards==true)
			{
			if (gameObject.name=="player1")
			{
				thecardsobj.GetComponent<cards>().hideplayer2hand();
					Debug.Log("currentplayer:"+thecardsobj.GetComponent<cards>().thecurrentplayer.name);
					thecardsobj.GetComponent<cards>().thecurrentplayer=thecardsobj.GetComponent<gamemanager>().player1obj;
			}

				if (gameObject.name=="player2")
				{
					Debug.Log("active player2s cards");
				thecardsobj.GetComponent<cards>().hideplayer1hand();

					thecardsobj.GetComponent<cards>().thecurrentplayer=thecardsobj.GetComponent<gamemanager>().player2obj;
				}
				showthecards=false;
			}


			if (showingtext==false)
			{
			//show turntext
			showturntext.SetActive(true);
				showingtext=true;
			}




			//update no. of moves
			showmovedremainingtxt.text=""+movesperturn;


			//rolldice
			if(hasrolled==false)
			{
			rolldice();
			}



			if (hasmoved==false&&hasrolled==true)
			{
				if (movesperturn>0)
				{
				movetheplayer(this.gameObject);
				}

			}

			if (cansuggest==true)
			{
				
			}

			if (hasrolled==true&&movesperturn<1&&turnended==true)
			{
				Debug.Log("change player");

				hasmoved=true;
				hasturn=false;
				hasrolled=false;
				showingtext=false;
				showthecards=true;
				//cansuggest==false;

				//movephase ended	
			}

			if (Input.GetKeyDown(spacekey))
			{
				turnended=true;
			}




		}
		else{showturntext.SetActive(false);}



	}//end update


	public GameObject movetheplayer(GameObject pturn)
	{
			currentpos=pturn.transform.position;//get current
			if (Input.GetKeyDown(upkey))
			{
			goup();
			}

			if (Input.GetKeyDown(downkey))
			{
			godown();
			}

			if (Input.GetKeyDown(rightkey))
			{
			goright();
			}


			if (Input.GetKeyDown(leftkey))
			{
			goleft();
			}






		if (Input.GetMouseButtonDown(0))
		{

			Debug.Log("click");

			if (Input.GetMouseButtonDown(0)) {
				RaycastHit hit;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
			
					Debug.Log(""+ hit.point);
					markerObject.transform.position=(hit.point);

				}
			}





			xpos=markerObject.transform.position.x-pturn.transform.position.x ;
			ypos=markerObject.transform.position.z-pturn.transform.position.z ;


			if (ypos<0.2f&&ypos>-0.2f)
			{
				if (xpos<0)
				{
					Debug.Log("go left click");
					goleft();


				}
				else{
					if (xpos>0)
				{
					Debug.Log("go right  click");
					goright();

					}
				}
			}

			if(xpos<0.2f&&xpos>-0.2f)
			{
				if (ypos>0)
				{
					Debug.Log("go up click");
					goup();

				}
				else{
					if (ypos<0)
					{
						Debug.Log("go down  click");
						godown();

					}
				}
			}//xposypos


		}//mousedown

			return pturn;
		}




	public void rolldice()
	{
	movesperturn=Random.Range(1,6);
		thedie.GetComponent<dice>().rollnow=true;
	hasrolled=true;
			}

	public void goleft()
	{
		Debug.Log("go left click");
		currentpos+=new Vector3(-movedistance,0,0);
		transform.position=currentpos;
		movesperturn--;
	}
	public void goright()
	{
		Debug.Log("go left click");
		currentpos+=new Vector3(movedistance,0,0);
		transform.position=currentpos;
		movesperturn--;
	}
	public void goup()
	{
		currentpos+=new Vector3(0,0,movedistance);
	transform.position=currentpos;
		movesperturn--;
	}
	public void godown()
	{
		currentpos+=new Vector3(0,0,-movedistance);
		transform.position=currentpos;
		movesperturn--;
	}
}
