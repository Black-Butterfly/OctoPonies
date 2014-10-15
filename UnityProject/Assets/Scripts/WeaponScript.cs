using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  collision)
	{
		DestructibleScript CS = collision.gameObject.GetComponent<DestructibleScript>();
		if (CS != null)
		{
			Destroy(collision.gameObject);
		}
	}
	void Start () {
	
	}
	void Update () {
	
	}
}
