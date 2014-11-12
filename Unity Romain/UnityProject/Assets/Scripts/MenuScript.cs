using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	private MenuTextScript mts;
	private string[] menu;
	private int choice = 0;
	private const int nbChoices = 4;
	
	void Start ()
	{
		Screen.showCursor = false;

		menu = new string[nbChoices];
		menu[0] = "Play";
		menu[1] = "Controls";
		menu[2] = "Credits";
		menu[3] = "Exit";

		mts =  GameObject.Find(menu[choice]).GetComponent<MenuTextScript>();
		mts.Focus();
	}

	void Update ()
	{
		if(Input.GetKeyDown("down"))
		{
			choice = ++choice % nbChoices;

			mts.UnFocus();
			mts =  GameObject.Find(menu[choice]).GetComponent<MenuTextScript>();
			mts.Focus();
		}
		else if(Input.GetKeyDown("up"))
		{
			choice = Mathf.Abs((--choice + nbChoices) % nbChoices);
			
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
				Application.LoadLevel("Credits");
				break;
			case 3 :
				Application.Quit();
				break;
			default:
				break;
			}
		}
	}
}
