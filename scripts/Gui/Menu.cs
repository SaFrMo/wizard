using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public enum State
	{
		Title,
		Main
	}

	public State state = State.Main;

	private void OnGUI ()
	{
		switch (state) {

		case State.Title:
			RunTitleMenu();
			break;


		//case State.Main:
			//GUILayout.BeginArea(new Rect 


		}
	}

	private void Update ()
	{
		logoRectX = iTween.FloatUpdate (logoRectX, Screen.width * .2f, logoSpeed * Time.deltaTime);
	}

	public Texture2D logo;
	public float logoSpeed = 2f;
	private bool runningTitle = false;
	private Rect logoRect;
	private float logoRectX;
	private void RunTitleMenu ()
	{
		GUI.DrawTexture (new Rect (logo.width / 2f - logoRectX, logo.height / 2f - Screen.height * .4f, logo.width, logo.height), logo);
		if (GUI.Button (new Rect (50f, Screen.height - 100f, 200f, 200f), "Start Game")) { state = State.Main; }
	}

	private void ShowButton()
	{

	}
}
