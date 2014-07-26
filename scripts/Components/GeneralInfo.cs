using UnityEngine;
using System.Collections;

public class GeneralInfo : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<Water>() != null)
			isInWater = true;
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
