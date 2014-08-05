using UnityEngine;
using System.Collections;

public class WindPosition : MonoBehaviour {

	public float xPos;
	public float yPos;

	void WindSpell ()
	{	
		transform.Translate (Screen.width * xPos, Screen.height * yPos, 1);
	}
}
