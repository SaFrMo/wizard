using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	public GameObject lightning;
	public static GameObject lightningStatic;
	public float lightningSpeed;
	public static float lightningSpeedStatic;

	private void Start ()
	{
		lightningStatic = lightning;
		lightningSpeedStatic = lightningSpeed;
	}

	public static void CreateLightningSprite()
	{
		print ("lightning!");
		GameObject lGo = GameObject.Instantiate(lightningStatic) as GameObject;

		Vector2 goalPoint = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width * .66f, Screen.height - 40f));

		// scoot in from the side of the screen
		iTween.MoveTo (lGo, new Hashtable() {
			{ iT.MoveTo.x, goalPoint.x },
			{ iT.MoveTo.y, goalPoint.y },
			{ iT.MoveTo.time, lightningSpeedStatic },
			{ iT.MoveTo.easetype, iTween.EaseType.easeOutElastic }
		});
	}
}
