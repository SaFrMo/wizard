using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class AffectedByWind : MonoBehaviour {

	public enum Effect
	{
		MovedByWind,
		MovesPlayer
	}

	public Effect effect = Effect.MovedByWind;

	public Vector2 movesPlayerDirection = Vector2.up;
	public float strength = 3f;
	
	private Vector2 targetPosition;

	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.MovedByWind:
			// Move this object spacesToMove spaces away from source
			// TODO: move farther when closer?

			targetPosition = Vector2.MoveTowards ((Vector2)transform.position,
			                                      targetPosition,
			                                      -strength);

			//transform.position = targetPosition;

			iTween.MoveTo (gameObject, new Hashtable() {
				{ iT.MoveTo.x, targetPosition.x },
				{ iT.MoveTo.time, 3f },
				{ iT.MoveTo.easetype, iTween.EaseType.easeOutCubic }
			});
			break;

		case Effect.MovesPlayer:
			print (Wizard.WIZARD.name);
			Wizard.WIZARD.rigidbody2D.AddForce (movesPlayerDirection * strength * Time.deltaTime, ForceMode2D.Force);
			break;
		}
	}
}
