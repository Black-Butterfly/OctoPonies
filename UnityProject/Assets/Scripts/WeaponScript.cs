using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  collision)
	{
		Debug.Log("COUCOU");
		DestructibleScript CS = collision.gameObject.GetComponent<DestructibleScript>();
		if (CS != null)
		{
			Debug.Log("COLLISION");
			Destroy(collision.gameObject);
		}
	}
	void Start () {
	
	}
	void Update () {
	
	}
}
