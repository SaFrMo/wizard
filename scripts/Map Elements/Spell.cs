using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Spell : MonoBehaviour {

	public enum SpellType
	{
		Wind,
		Earth,
		Lightning,
		Rain,
		Return
	}

	private delegate void SpellAction();
	
	public SpellType spellType = SpellType.Wind;
	public int range = 5;

	private bool lockShowRange = false;
	private bool mouseIsOver = false;

	/// <summary>
	/// Activates the spell.
	/// </summary>
	private void ActivateSpell()
	{
		// First, get everything within range
		Collider2D[] inRange = Physics2D.OverlapAreaAll ((Vector2)transform.position - Vector2.one * range,
		                                                 (Vector2)transform.position + Vector2.one * range);

		// Figure out the appropriate spell effect and apply it
		switch (spellType) {

		case SpellType.Wind:
			foreach (Collider2D c in inRange) {
				try { c.gameObject.GetComponent<AffectedByWind>().ApplyEffect((Vector2)transform.position); }
				catch {}
			}
			break;

		case SpellType.Earth:
			foreach (Collider2D c in inRange) {
				try { c.gameObject.GetComponent<AffectedByEarth>().ApplyEffect((Vector2)transform.position); }
				catch {}
			}
			break;

		case SpellType.Lightning:
			foreach (Collider2D c in inRange) {
				try { c.gameObject.GetComponent<AffectedByLightning>().ApplyEffect((Vector2)transform.position); }
				catch {}
			}
			break;

		case SpellType.Rain:
			Water.RainSpell();
			break;

		case SpellType.Return:
			Wizard.ReturnSpell();
			break;


		}
		Destroy (gameObject);
	}

	// Wizard collision with spell = spell activation
	private void OnCollisionEnter2D (Collision2D c)
	{
		// Makes sure it's the wizard
		if (c.collider.gameObject.GetComponent<Wizard>() != null)
		{
			ActivateSpell();
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}


	// RANGE ===============================================
	private void OnMouseEnter() { mouseIsOver = true; }
	private void OnMouseExit() { mouseIsOver = false; }

	// UPDATE ==============================================	
	private void Update ()
	{
		if (mouseIsOver && Input.GetMouseButtonDown(0))
			lockShowRange = !lockShowRange;

		// TODO: show range
		if (mouseIsOver || lockShowRange) 
			print ("showing range");
	}
}
