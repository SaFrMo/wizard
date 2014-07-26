using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Spell : MonoBehaviour {

	public enum SpellType
	{
		Wind,
		Earth,
		Lightning,
		Rain,
		Ice,
		Return,
		Phase
	}

	private delegate void SpellAction();
	
	public SpellType spellType = SpellType.Wind;
	public int range = 5;

	private bool lockShowRange = false;
	private bool mouseIsOver = false;
	private GameObject rangeIndicator = null;

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
			Lightning.CreateLightningSprite();
			foreach (Collider2D c in inRange) {
				try { c.gameObject.GetComponent<AffectedByLightning>().ApplyEffect((Vector2)transform.position); }
				catch {}
			}

			break;

		case SpellType.Rain:
			Water.RainSpell();
			break;

		case SpellType.Ice:
			foreach (Collider2D c in inRange) {
				try { c.gameObject.GetComponent<AffectedByIce>().ApplyEffect((Vector2)transform.position); }
				catch {}
			}
			break;

		case SpellType.Return:
			Wizard.ReturnSpell();
			break;


		}
		Wizard.WIZARD.GetComponent<Wizard>().AnimateSpell(spellType);
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

		if ((mouseIsOver || lockShowRange)) {
			if (rangeIndicator == null) {
				rangeIndicator = GameObject.Instantiate(gameObject) as GameObject;
				rangeIndicator.transform.localScale = new Vector3(rangeIndicator.transform.localScale.x * range,
				                                                  rangeIndicator.transform.localScale.y * range);
				Destroy (rangeIndicator.GetComponent<Spell>());
				Destroy (rangeIndicator.GetComponent<Collider2D>());
				rangeIndicator.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, .2f);
			}
		}

		else { Destroy(rangeIndicator); }
	}
}
