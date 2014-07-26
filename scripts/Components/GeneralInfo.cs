using UnityEngine;
using System.Collections;

public class GeneralInfo : MonoBehaviour {

	public bool isEndPortal = false;

	private void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<Water>() != null)
			isInWater = true;
		else if (isEndPortal && c.gameObject.GetComponent<Wizard>() != null)
			// TODO: Win level
			print ("You win!");
	}

	private void OnTriggerStay2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<Water>() != null)
			isInWater = true;
	}
	
	private void OnTriggerExit2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<Water>() != null)
			isInWater = false;
	}

	public bool isInWater = false;

	public void Kill()
	{
		//TODO
		print (gameObject.name + " is slain");
		Destroy (gameObject);

	}

	private void Update()
	{
		print (isInWater);
	}

}
