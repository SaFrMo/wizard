using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour {

	public static string SELECTED_SPELL = "No Spell";
	public static bool going = false;
	public static void Go() { going = true; }
	public static void Stop() { going = false; }

	public float speed = 3f;

	private void Update ()
	{
		if (!going) return;

		rigidbody2D.MovePosition ((Vector2)transform.position + Vector2.right * speed * Time.deltaTime);
	}


}
