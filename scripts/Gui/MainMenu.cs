﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture2D titleLogo, playButton, quitButton, settingsButton, infoButton;
	public Texture2D menuBackground;
	public string chosenLevel;

	void OnGUI () {
		GUI.DrawTexture(new Rect(0,0, 
		                   Screen.width, 
		                   Screen.height), menuBackground, ScaleMode.StretchToFill);
		GUI.Label(new Rect(Screen.width * .3f, 0, 
		                   Screen.width * .4f, 
		                   Screen.width * .4f), titleLogo, GUIStyle.none);
		if (GUI.Button(new Rect(Screen.width * .45f,
		                        Screen.height * .75f,
		                        Screen.width * .2f,
		                        Screen.height * .1f), playButton, GUIStyle.none))
		{
			Application.LoadLevel(chosenLevel);
		}
		if (GUI.Button(new Rect(Screen.width * .45f,
		                        Screen.height * .85f,
		                        Screen.width * .2f,
		                        Screen.height * .1f), quitButton, GUIStyle.none))
		{
			Application.Quit();
		}
		if (GUI.Button(new Rect(0, 0,
		                        Screen.width * .05f,
		                        Screen.width * .05f), settingsButton, GUIStyle.none))
		{
			Application.LoadLevel("settingsLevel");
		}
		if (GUI.Button(new Rect(Screen.width - (Screen.width * .05f),
		                        0,
		                        Screen.width * .05f,
		                        Screen.width * .05f), infoButton, GUIStyle.none))
		{
			Application.LoadLevel("infoLevel");
		}
	}
}
