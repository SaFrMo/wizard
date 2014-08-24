using UnityEngine;
using System.Collections;

public class AffectedByEarth : MonoBehaviour {

	public enum Effect
	{
		Crumble
	}

	public Effect effect = Effect.Crumble;

	private void Start ()
	{
		// Apply RocksSettle to all children
		foreach (Transform child in transform)
		{
			if (child.gameObject.GetComponent<RocksSettle>() == null)
				child.gameObject.AddComponent<RocksSettle>();
			if (child.gameObject.GetComponent<Collider2D>() != null)
				child.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

	public void ApplyEffect (Vector2 source)
	{
		switch (effect) {

		case Effect.Crumble:
			// Destroy this collider and let the pieces fall
			GetComponent<Collider2D>().enabled = false;
			foreach (Transform child in transform)
			{
				child.gameObject.GetComponent<RocksSettle>().Settle();
			}


			Destroy (gameObject);
			break;

		}
	}
}
