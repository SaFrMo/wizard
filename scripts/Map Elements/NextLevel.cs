using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string levelName;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player"))
			Application.LoadLevel(levelName);
	}
}