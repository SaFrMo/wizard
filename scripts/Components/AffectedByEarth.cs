using UnityEngine;
using System.Collections;

public class AffectedByEarth : MonoBehaviour {

	public enum Effect
	{
		Crumble
	}

	public Effect effect = Effect.Crumble;

	public void ApplyEffect (Vector2 source)
	{
		switch (effect) {

		case Effect.Crumble:
			// Destroy this collider and let the pieces fall
			GetComponent<Collider2D>().enabled = false;
			foreach (Transform child in transform)
			{
				child.GetComponent<PolygonCollider2D>().enabled = true;
				child.gameObject.AddComponent<Rigidbody2D>();
				//child.rigidbody2D.
				child.transform.parent = null;
			}


			Destroy (gameObject);
			break;

		}
	}
}
