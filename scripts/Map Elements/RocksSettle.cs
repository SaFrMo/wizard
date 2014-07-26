using UnityEngine;
using System.Collections;

public class RocksSettle : MonoBehaviour {

	public void Settle()
	{
		GetComponent<PolygonCollider2D>().enabled = true;
		gameObject.AddComponent<Rigidbody2D>();
		transform.parent = null;
		gameObject.layer = 8;
	}
}
