/**
 * @file    MenuScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gère le menu principale.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe MenuScript gère le menu principale.
 *
 */
public class MenuScript : MonoBehaviour {

	/** @brief mts contiendra le script MenuTextScript du bouton selectionné */
	private MenuTextScript mts;
	/** @brief menu tableau contenant les choix du menu possible */
	private string[] menu;
	/** @brief choice choix actuellement selectionné */
	private int choice = 0;
	/** @brief nbChoices nombre de choix total au menu */
	private const int nbChoices = 4;

	/**
     * S'execute lors de la création du script.
     * Cache le pointeur au lancement du jeu.
     * Initialise le menu et met le focus sur le 1er choix.
     *
     */
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

	/**
	 * Appellé à chaque frame
     * Gère le menu. Change le focus en fonction des touches appuyé, gère les actions.
     *
     */
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
