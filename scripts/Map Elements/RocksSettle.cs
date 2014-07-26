using UnityEngine;
using System.Collections;

public class RocksSettle : MonoBehaviour {

	public void Settle()
	{
		GetComponent<PolygonCollider2D>().enabled = true;
		gameObject.AddComponent<Rigidbody2D>();
		transform.parent = null;
		gameObject.layer = 8;
		s = GetComponent<SpriteRenderer>();
		StartCoroutine ("FadeAway");
	}

	SpriteRenderer s;

	private IEnumerator FadeAway()
	{
		for (int i = 100; i > 0; i--)
		{
			s.color = new Color(s.color.r,
			                    s.color.g,
			                    s.color.b,
			                    i / 100f);
			yield return null;

		}
	}
}
