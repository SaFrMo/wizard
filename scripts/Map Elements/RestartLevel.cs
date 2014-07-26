using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D c)
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
}
