using UnityEngine;
using System;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public float spellSelectionBoxHeight = 100f;

	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect(Screen.width * .1f,
		                              Screen.height - spellSelectionBoxHeight,
		                              Screen.width * .8f,
		                              spellSelectionBoxHeight));
		GUILayout.BeginHorizontal();
		foreach (string s in Enum.GetNames(typeof(Spell.SpellType)))
		{
			if (GUILayout.Button(s))
			{
				Wizard.SELECTED_SPELL = s;
			}
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if (GUILayout.Button ("GO!"))
			Wizard.Go();
		if (GUILayout.Button ("Restart level!"))
			Application.LoadLevel (Application.loadedLevelName);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
