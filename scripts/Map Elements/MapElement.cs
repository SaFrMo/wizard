using UnityEngine;
using System.Collections;

public class MapElement : MonoBehaviour {

	public bool affectedByWind = false;

	public void ApplyWind (Vector2 source)
	{
		if (!affectedByWind) return;
	}
}
