using UnityEngine;
using System.Collections;

public class AffectedByIce : MonoBehaviour {

	public enum Effect
	{
		Freeze
	}
	
	public Effect effect = Effect.Freeze;
	
	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.Freeze:
			// Turns a water trigger into a solid collider
			GetComponent<Collider2D>().isTrigger = false;
			try { GetComponent<Water>().frozen = true; }
			catch {}
			break;
		}
	}
}
