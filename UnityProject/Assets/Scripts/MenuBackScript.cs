/**
 * @file    MenuBackScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gère le bouton back des menus.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe MenuBackScript gère le bouton back.
 *
 */
public class MenuBackScript : MonoBehaviour {

	/**
     * S'execute lors de la création du script.
     * Récupère le bouton back et met le focus dessus.
     *
     */
	void Awake()
	{
		MenuTextScript mts = gameObject.GetComponent<MenuTextScript>();
		mts.Focus();
	}

	/**
	 * Appellé à chaque frame
     * Si la touche echap ou entré est appuyé, retour au menu principale.
     *
     */
	void Update()
	{
		if(Input.GetKey("escape") || Input.GetKey("return"))
		{
			Application.LoadLevel("Menu");
		}
	}
}
