using UnityEngine;
using System.Collections;

public class AffectedByWater : MonoBehaviour {

	public enum Effect
	{
		NeedsWaterToSurvive
	}
	
	public Effect effect = Effect.NeedsWaterToSurvive;

	public bool isInWater = false;



	
	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.NeedsWaterToSurvive:
			// TODO
			break;
		}
	}
}
