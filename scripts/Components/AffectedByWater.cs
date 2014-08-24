using UnityEngine;
using System.Collections;

public class AffectedByWater : MonoBehaviour {

	public enum Effect
	{
		NeedsWaterToSurvive,
		Floats
	}
	
	public Effect effect = Effect.NeedsWaterToSurvive;

	public static System.Collections.Generic.List<GameObject> ALL_AFFECTED_BY_WATER = new System.Collections.Generic.List<GameObject>();

	private SpringJoint2D spring = null;

	private Vector2 targetPosition;

	private void LockNewPosition ()
	{
		rigidbody2D.MovePosition(new Vector2(transform.position.x,
		                              	Wizard.WIZARD.GetComponent<GeneralInfo>().water.renderer.bounds.max.y));
		rigidbody2D.gravityScale = 0;
	}
	
	public void ApplyEffect (Vector2 source) 
	{
		switch (effect) {
		case Effect.NeedsWaterToSurvive:
			if (!GetComponent<GeneralInfo>().isInWater)
				GetComponentInParent<GeneralInfo>().Kill();
			break;
		case Effect.Floats:
			if (spring == null && GetComponent<GeneralInfo>().isInWater)
			{
				spring = gameObject.AddComponent<SpringJoint2D>();
				spring.anchor = (Vector2)GetComponent<BoxCollider2D>().bounds.center.normalized;
				spring.connectedAnchor = new Vector2 (transform.position.x,
				                             		  GetComponent<GeneralInfo>().water.renderer.bounds.max.y);
				spring.distance = .1f;
				spring.dampingRatio = 10f;
				spring.frequency = 0;
				rigidbody2D.gravityScale = .1f;
				spring.enabled = false;
				spring.enabled = true;
			}

			else if (spring != null)
			{
				spring.anchor = (Vector2)GetComponent<BoxCollider2D>().center;
				spring.connectedAnchor = new Vector2 (transform.position.x,
				                                      GetComponent<GeneralInfo>().water.renderer.bounds.max.y);
				spring.distance = .1f;
			}

			/*
			if (GetComponent<GeneralInfo>().isInWater && GetComponent<GeneralInfo>().water.renderer.bounds.max.y - transform.position.y > 2f)
			{

				// the transform.position must equal the top of the water
				iTween.MoveTo (gameObject, new Hashtable() {
					{ iT.MoveTo.y, GetComponent<GeneralInfo>().water.renderer.bounds.max.y },
					{ iT.MoveTo.speed, 2f },
					{ iT.MoveTo.easetype, iTween.EaseType.easeOutElastic },
					{ iT.MoveTo.oncomplete, "LockNewPosition" }
				});

			}
			*/
			break;
		}
	}

	public void UpdateWater() {
		if (spring != null) {
			spring.connectedAnchor = new Vector2 (transform.position.x,
			                                      GetComponent<GeneralInfo>().water.renderer.bounds.max.y);	
		}
	}

	private void Start ()
	{
		Invoke ("Check", .5f);
		ALL_AFFECTED_BY_WATER.Add(gameObject);
		spring.enabled = false;
		spring.enabled = true;
	}

	private void Check ()
	{
		if (effect == Effect.NeedsWaterToSurvive || effect == Effect.Floats)
			StartCoroutine("CheckForWater");
	}

	private IEnumerator CheckForWater ()
	{
		for (;;)
		{
			ApplyEffect(Vector2.zero);
			yield return new WaitForSeconds(.4f);
		}
	}
}
