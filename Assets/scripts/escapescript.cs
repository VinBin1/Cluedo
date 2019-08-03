using UnityEngine;
using System.Collections;

public class escapescript : MonoBehaviour {
	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();

	}
}