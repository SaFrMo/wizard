using UnityEngine;
using System.Collections;

public class SpellPlacement : MonoBehaviour {

	public KeyCode cancelKey = KeyCode.LeftShift;
	
	public GameObject spellPrefab;
	public GameObject spellPlacerPrefab;
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
		// only activate when the new planter would not interfere with an old one
		GameObject spell = GameObject.Instantiate (spellPrefab) as GameObject;
		spell.transform.position = selectedPosition;
		
		// unique name for each custom planter
		spell.gameObject.name = string.Format ("New Spell");
		
		// clear planter placer
		Destroy (spellPlacer);
	}
	
	protected void Update () {
		if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0) {
			SelectPlanterLocation();
		}
		if (Input.GetMouseButtonUp(0) && GUIUtility.hotControl == 0) {
			if (!Input.GetKey(cancelKey) && spellPlacer != null) {
				print ("mouse up...");
				// can only create a planter if it doesn't overlap another
				Collider2D otherSpells = Physics2D.OverlapArea (spellPlacer.renderer.bounds.min, spellPlacer.renderer.bounds.max);
				if (otherSpells == null)
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
