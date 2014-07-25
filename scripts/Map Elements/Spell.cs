using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Spell : MonoBehaviour {

	public enum SpellType
	{
		Wind
	}

	private delegate void SpellAction();
	
	public SpellType spellType = SpellType.Wind;
	public int range = 5;

	private bool lockShowRange = false;
	private bool mouseIsOver = false;

	private void ActivateSpell()
	{
		switch (spellType)
		{
		case SpellType.Wind:
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

	// Show range on mouse over
	private void OnMouseEnter()
	{
		mouseIsOver = true;
	}

	private void OnMouseExit()
	{
		mouseIsOver = false;
	}

	private void Update ()
	{
		if (mouseIsOver && Input.GetMouseButtonDown(0))
			lockShowRange = !lockShowRange;

		// TODO: show range
		if (mouseIsOver || lockShowRange) 
			print ("showing range");
	}
}
