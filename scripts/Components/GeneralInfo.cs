using UnityEngine;
using System.Collections;

public class GeneralInfo : MonoBehaviour {

	public bool isEndPortal = false;

	private void OnCollisionEnter2D (Collision2D c)
	{
		if (isEndPortal && c.gameObject.GetComponent<Wizard>() != null)
			// TODO: Win level
			print ("You win!");
	}

	private void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<Water>() != null) {
			isInWater = true; 
			water = c.gameObject;
		}
	}

	private void OnTriggerStay2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<Water>() != null && !c.gameObject.GetComponent<Water>().frozen)
			isInWater = true;
		else 
			isInWater = false;
	}


	private void OnTriggerExit2D (Collider2D c)
	{

		if (c.gameObject.GetComponent<Water>() != null)
			isInWater = false; if (water == c) water = null;
	}
	
	public GameObject water = null;
	
	public bool isInWater = false;

	public void Kill()
	{
		//TODO
		print (gameObject.name + " is slain");
		Destroy (gameObject);

	}

	private void Update()
	{
	}

}
