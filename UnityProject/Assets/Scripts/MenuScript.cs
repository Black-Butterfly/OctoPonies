using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	private MenuTextScript mts;
	private string[] menu;
	private int choice = 0;
	
	void Start ()
	{
		Screen.showCursor = false;

		menu = new string[3];
		menu[0] = "Play";
		menu[1] = "Controls";
		menu[2] = "Exit";

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
				Application.LoadLevel("Lvl1");
				break;
			case 1:
				Application.LoadLevel("KeyConfig");
				break;
			case 2 :
				Application.Quit();
				break;
			default:
				break;
			}
		}
	}
}
