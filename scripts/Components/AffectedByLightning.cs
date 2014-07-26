using UnityEngine;
using System.Collections;

public class AffectedByLightning : MonoBehaviour {

	public enum Effect
	{
		CanBeShocked
	}
	
	public Effect effect = Effect.CanBeShocked;
	
	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.CanBeShocked:
			print ("shocking!");
			if (gameObject.GetComponent<GeneralInfo>().isInWater) {
				gameObject.GetComponent<GeneralInfo>().Kill ();
				print ("shocked!");
			}
			break;
		}
	}
}
