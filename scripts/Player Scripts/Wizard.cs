using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour {

	public static string SELECTED_SPELL = "No Spell";
	public static bool going = false;
	public static void Go() { going = true; }
	public static void Stop() { going = false; }

	public float speed = 3f;

	private bool climbingLadder = false;

	private void OnCollisionEnter2D (Collision2D c)
	{
		if (c.collider.gameObject.GetComponent<Ladder>() != null)
		{
			climbingLadder = true;
		}
	}

	private void OnCollisionExit2D (Collision2D c)
	{
		if (c.collider.gameObject.GetComponent<Ladder>() != null)
			climbingLadder = false;
	}

	private void Update ()
	{
		if (!going) return;

		rigidbody2D.MovePosition ((Vector2)transform.position 
		                          + (climbingLadder ? Vector2.up : Vector2.right)
		                          * speed * Time.deltaTime);
	}


}
