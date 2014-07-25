using UnityEngine;
using System.Collections;

public class AffectedByWind : MonoBehaviour {

	public enum Effect
	{
		MovedByWind
	}

	public Effect effect = Effect.MovedByWind;
	
	public float spacesToMove = 3f;
	
	private Vector2 targetPosition;

	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.MovedByWind:
			// Move this object spacesToMove spaces away from source
			// TODO: move farther when closer?
			targetPosition = Vector2.MoveTowards ((Vector2)transform.position,
			                                      targetPosition,
			                                      -spacesToMove);
			transform.position = targetPosition;
			break;
		}
	}
}
