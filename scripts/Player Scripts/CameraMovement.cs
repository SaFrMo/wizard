using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	const float SIGNAL_VALUE = 1000f;

	private Vector3 offset;
	private Transform parent;
	private bool setUpToGo = false;

	public GameObject farthestLeft = null;
	public GameObject farthestRight = null;
	public GameObject farthestUp = null;
	public GameObject farthestDown = null;

	private float farthestLeftPos = SIGNAL_VALUE;
	private float farthestRightPos = SIGNAL_VALUE;
	private float farthestUpPos = SIGNAL_VALUE;
	private float farthestDownPos = SIGNAL_VALUE;

	public float speed = 3f;

	private void Start ()
	{
		offset = transform.position;
		parent = transform.parent;
		transform.parent = null;

		if (farthestLeft != null)
			farthestLeftPos = farthestLeft.renderer.bounds.min.x + Camera.main.orthographicSize;
		if (farthestRight != null)
			farthestRightPos = farthestRight.renderer.bounds.max.x - Camera.main.orthographicSize;

		if (farthestUp != null)
			farthestUpPos = farthestUp.renderer.bounds.max.y - Camera.main.orthographicSize;
		if (farthestDown != null)
			farthestDownPos = farthestDown.renderer.bounds.min.y + Camera.main.orthographicSize;

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

		transform.position = new Vector3(farthestLeftPos == SIGNAL_VALUE || farthestRightPos == SIGNAL_VALUE 
		                                 ? transform.position.x 
		                                 : Mathf.Clamp(transform.position.x, farthestLeftPos, farthestRightPos),
		                                 farthestUpPos == SIGNAL_VALUE || farthestDownPos == SIGNAL_VALUE
		                                 ? transform.position.y
		                                 : Mathf.Clamp(transform.position.y, farthestDownPos, farthestUpPos),
		                                 transform.position.z);

	}
}
