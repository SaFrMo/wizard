using UnityEngine;
using System.Collections;

public class SpellPlacement : MonoBehaviour {

	public GameObject windSpell;
	public GameObject earthSpell;
	public GameObject lightningSpell;
	public GameObject returnSpell;

	public KeyCode cancelKey = KeyCode.LeftShift;
	

	public GameObject spellPlacerPrefab;
	private GameObject spellPrefab;
	private GameObject spellPlacer = null;
	
	private Vector2 selectedPosition;
	
	public void SelectPlanterLocation () {
		selectedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// converts position to Vector2 and snaps to a 1x1 grid
		selectedPosition = new Vector2 (Mathf.Round(selectedPosition.x),
		                                Mathf.Round(selectedPosition.y));
		
		// instantiates an object to show where the planter will go
		if (spellPlacer == null) {
			spellPlacer = GameObject.Instantiate (spellPlacerPrefab) as GameObject;
			try { spellPlacer.GetComponent<Collider2D>().enabled = false; }
			catch {}
		}
		
		spellPlacer.transform.position = selectedPosition;
	}
	
	public void CreateSpell () {

		switch (Wizard.SELECTED_SPELL)
		{

		case "No Spell":
			spellPrefab = null;
			break;

		case "Wind":
			spellPrefab = windSpell;
			break;

		case "Earth":
			spellPrefab = earthSpell;
			break;

		case "Lightning":
			spellPrefab = lightningSpell;
			break;

		case "Return":
			spellPrefab = returnSpell;
			break;

		}

		// clear planter placer
		Destroy (spellPlacer);

		if (spellPrefab == null) 
			return;

		GameObject spell = GameObject.Instantiate (spellPrefab) as GameObject;
		spell.transform.position = selectedPosition;
		spell.name = Wizard.SELECTED_SPELL + " Spell";
	}
	
	protected void Update () {
		if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0) {
			SelectPlanterLocation();
		}
		if (Input.GetMouseButtonUp(0) && GUIUtility.hotControl == 0) {
			if (!Input.GetKey(cancelKey) && spellPlacer != null) {
				// can only create a planter if it doesn't overlap another
				Collider2D otherSpells = Physics2D.OverlapArea (spellPlacer.renderer.bounds.min, spellPlacer.renderer.bounds.max);
				// Only water can be a spell collider
				if (otherSpells == null || otherSpells.gameObject.GetComponent<Water>() != null)
					CreateSpell();
				else
					Destroy (spellPlacer);
			}
			else {
				// cancel creation and destroy the placer guide
				Destroy (spellPlacer);
			}
		}
	}
}
