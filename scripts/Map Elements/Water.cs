using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Water : MonoBehaviour {

	public static float riseAmount;
	public static List<GameObject> ALL_WATER = new List<GameObject>();
	public static float rainRate = 1f;
	//public static GameObject STATIC_WATER;

	public static void RainSpell()
	{
		foreach (GameObject go in ALL_WATER)
		{
			if (go != null)
			{
				iTween.ScaleTo(go, new Hashtable() {
					{ iT.ScaleTo.y, go.transform.localScale.y + riseAmount },
					{ iT.ScaleTo.time, rainRate },
					{ iT.ScaleTo.easetype, iTween.EaseType.easeOutQuart },
					{ iT.ScaleTo.oncomplete, "UpdateWater" }
				});

				
					/*go.transform.localScale = new Vector3(go.transform.localScale.x,
				                                      go.transform.localScale.y + riseAmount,
				                                      go.transform.localScale.z);*/
			}
		}
	}

	public float rise = 5f;
	public bool frozen = false;

	public void UpdateWater() {
		if (AffectedByWater.ALL_AFFECTED_BY_WATER.Count <= 0) 
			return;
		foreach (GameObject go in AffectedByWater.ALL_AFFECTED_BY_WATER) {
			go.GetComponent<AffectedByWater>().UpdateWater();
		}
	}

	private void Awake ()
	{
		ALL_WATER.Add (gameObject);
		//STATIC_WATER = gameObject;
		riseAmount = rise;
	}
}
