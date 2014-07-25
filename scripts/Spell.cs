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

	private void ActivateSpell()
	{
		switch (spellType)
		{
		case SpellType.Wind:
			break;
		}
	}

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
}
