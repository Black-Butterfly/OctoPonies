/**
 * @file    PauseMenuScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion du menu pause.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe PauseMenuScript gère le menu de pause.
 *
 */
public class PauseMenuScript : MonoBehaviour {

	/** @brief ms contiendra le script pour géré la musique */
	private MusicScript ms;
	/** @brief mts contiendra le script pour géré le texte */
	private MenuTextScript mts;
	/** @brief menu tableau contenant les choix du menu possible */
	private string[] menu;
	/** @brief choice choix actuellement selectionné */
	private int choice = 0;

	/**
     * S'execute lors de la création du script.
     * Initialise les variables et met le focus sur le 1er choix.
     *
     */
	void Start()
	{
		ms = GameObject.Find("Music").GetComponent<MusicScript>();

		Vector3 localPosition = GameObject.Find("Main Camera").transform.position;

		GameObject sprite = this.transform.GetChild(0).gameObject;
		sprite.transform.position = new Vector3(localPosition.x, localPosition.y, localPosition.z + 10);

		menu = new string[3];
		menu[0] = "Resume";
		menu[1] = "Restart";
		menu[2] = "MainMenu";

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
				ms.StopPlaying();
				AudioListener.pause = false;
				Application.LoadLevel("Lvl1");
				break;
			case 2 :
				ms.StopPlaying();
				AudioListener.pause = false;
				Application.LoadLevel("Menu");
				break;
			default:
				break;
			}
		}
	}
}