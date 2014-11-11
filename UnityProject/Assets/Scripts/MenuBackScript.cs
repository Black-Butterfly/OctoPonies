using UnityEngine;
using System.Collections;

public class MenuBackScript : MonoBehaviour {

	void Awake()
	{
		MenuTextScript mts = gameObject.GetComponent<MenuTextScript>();
		mts.Focus();
	}

	void Update()
	{
		if(Input.GetKey("escape") || Input.GetKey("return"))
		{
			Application.LoadLevel("Menu");
		}
	}
}
