using UnityEngine;
using System.Collections;

public class LightObject : MapElement {

	public float spacesToMove = 3f;

	private Vector2 targetPosition;

	public new void ApplyWind (Vector2 source) 
	{
		base.ApplyWind(source);

		// Move this object spacesToMove spaces away from source
		// TODO: move farther when closer?
		targetPosition = Vector2.MoveTowards ((Vector2)transform.position,
		                                      targetPosition,
		                                      -spacesToMove);
		transform.position = targetPosition;


	}
}
