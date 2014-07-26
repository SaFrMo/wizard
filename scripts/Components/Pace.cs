using UnityEngine;
using System.Collections;

public class Pace : MonoBehaviour {

	public float speed = 3f;
	private bool goingRight = true;

	private void OnCollisionEnter2D (Collision2D c)
	{
		if (c.collider.gameObject.GetComponent<Wizard>() != null)
			c.collider.gameObject.GetComponent<GeneralInfo>().Kill ();
		else
			transform.localScale = new Vector3 (-transform.localScale.x,
			                                    transform.localScale.y,
			                                    transform.localScale.z);
		goingRight = !goingRight;
	}

	private void Update ()
	{
		rigidbody2D.MovePosition ((Vector2)transform.position 
		                          + (goingRight ? Vector2.right : -Vector2.right)
		                          * speed * Time.deltaTime);
	}
}
