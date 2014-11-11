﻿using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	private MenuTextScript mts;
	private string[] menu;
	private int choice = 0;

	void Start()
	{
		Vector3 localPosition = GameObject.Find("Main Camera").transform.position;

		GameObject sprite = this.transform.GetChild(0).gameObject;
		sprite.transform.position = new Vector3(localPosition.x, localPosition.y, 0);

		menu = new string[3];
		menu[0] = "Resume";
		menu[1] = "Restart";
		menu[2] = "MainMenu";

		mts =  GameObject.Find(menu[choice]).GetComponent<MenuTextScript>();
		mts.Focus();
	}

	void Update ()
	{
		if(Input.GetKeyDown("down"))
		{
			choice = ++choice % 3;
			
			mts.UnFocus();
			mts =  GameObject.Find(menu[choice]).GetComponent<MenuTextScript>();
			mts.Focus();
		}
		else if(Input.GetKeyDown("up"))
		{
			choice = Mathf.Abs((--choice + 3) % 3);
			
			mts.UnFocus();
			mts =  GameObject.Find(menu[choice]).GetComponent<MenuTextScript>();
			mts.Focus();
		}
		else if(Input.GetKeyDown("return") || Input.GetKeyDown("space"))
		{
			switch (choice)
			{
			case 0:
				this.gameObject.SetActive(false);
				Time.timeScale = 1.0f;
				AudioListener.pause = false;
				Destroy(this);
				break;
			case 1:
				Application.LoadLevel("Lvl1");
				break;
			case 2 :
				Application.LoadLevel("Menu");
				break;
			default:
				break;
			}
		}
	}
}