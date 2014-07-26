using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Vector3 offset;
	private Transform parent;
	private bool setUpToGo = false;

	public float speed = 3f;

	private void Start ()
	{
		offset = transform.position;
		parent = transform.parent;
		transform.parent = null;
	}

	private void Update ()
	{
		if (Wizard.going && !setUpToGo)
		{
			transform.parent = parent;
			transform.position = offset;
			setUpToGo = true;
		}

		else
		{
			transform.position = new Vector3 (transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime,
			                                  transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime,
			                                  transform.position.z);
		}

	}
}
