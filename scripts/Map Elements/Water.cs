using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Water : MonoBehaviour {

	public static float riseAmount;
	public static List<GameObject> ALL_WATER = new List<GameObject>();

	public static void RainSpell()
	{
		foreach (GameObject go in ALL_WATER)
		{
			go.transform.localScale = new Vector3(go.transform.localScale.x,
			                                      go.transform.localScale.y + riseAmount,
			                                      go.transform.localScale.z);
		}
	}

	public float rise = 5f;
	public bool frozen = false;

	private void Start ()
	{
		ALL_WATER.Add (gameObject);
		riseAmount = rise;
	}
}
