using UnityEngine;
using System;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public Texture[] spellTex;
	public Texture goTex, redoTex;
	public int arraypos = 0;

	private void OnGUI ()
	{
		GUILayout.BeginArea (new Rect(0,
		                              0 + (Screen.height * .1f),
		                              Screen.height * .12f,
		                              Screen.height * .72f));
		GUILayout.BeginVertical();
		//GUI.color=Color(1.0,1.0,1.0,.0);
		foreach (Texture tex in spellTex)
						GUILayout.Box (tex, GUIStyle.none, GUILayout.Width (Screen.height * .12f), GUILayout.Height (Screen.height * .12f));
		//GUI.color=Color(1.0,1.0,1.0,.0);
		foreach (string s in Enum.GetNames(typeof(Spell.SpellType)))
		{
			if (GUILayout.Button(s, GUIStyle.none, GUILayout.Width (Screen.height * .12f), GUILayout.Height (Screen.height *.12f)))
			{
				Wizard.SELECTED_SPELL = s;
			}
		}




		GUILayout.EndVertical();
		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect(0,
		                              0 + (Screen.height * .9f),
		                              Screen.width * .3f,
		                              Screen.height * .15f));
		GUILayout.BeginHorizontal();
		if (GUILayout.Button (goTex, GUIStyle.none, GUILayout.Width (Screen.height * .15f), GUILayout.Height (Screen.height * .15f)))
			Wizard.Go();
		if (GUILayout.Button (redoTex, GUIStyle.none, GUILayout.Width (Screen.height * .15f), GUILayout.Height (Screen.height * .15f)))
			Application.LoadLevel (Application.loadedLevelName);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
