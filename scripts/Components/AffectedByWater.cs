using UnityEngine;
using System.Collections;

public class AffectedByWater : MonoBehaviour {

	public enum Effect
	{
		NeedsWaterToSurvive
	}
	
	public Effect effect = Effect.NeedsWaterToSurvive;




	
	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.NeedsWaterToSurvive:
			if (!GetComponent<GeneralInfo>().isInWater)
				GetComponentInParent<GeneralInfo>().Kill();
			break;
		}
	}

	private void Start ()
	{
		Invoke ("Check", .5f);

	}

	private void Check ()
	{
		if (effect == Effect.NeedsWaterToSurvive)
			StartCoroutine("CheckForWater");
	}

	private IEnumerator CheckForWater ()
	{
		for (;;)
		{
			ApplyEffect(Vector2.zero);
			yield return new WaitForSeconds(2f);
		}
	}
}
