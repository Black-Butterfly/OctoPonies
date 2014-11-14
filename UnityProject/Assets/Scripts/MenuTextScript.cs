/**
 * @file    MenuTextScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gère les textes.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe MenuTextScript gère les textes, taille, focus.
 *
 */
public class MenuTextScript : MonoBehaviour {

	/** @brief couleurFocus couleur du texte lorsqu'il a le focus */
	private Color couleurFocus = Color.green;
	/** @brief couleurUnFocus couleur du texte lorsqu'il n'a pas le focus */
	private Color couleurUnFocus = Color.black;
	/** @brief tailleFocus taille du texte lorsqu'il a le focus */
	private int tailleFocus;
	/** @brief tailleUnFocus taille du texte lorsqu'il n'a pas le focus */
	private int tailleUnFocus;

	/**
     * S'execute lors de la création du script.
     * Règle la taille du texte en fonction de la taille de l'écran.
     *
     */
	void Awake()
	{
		if(guiText.name == "Title")
		{
			guiText.fontSize = Screen.height/8;
		}
		else if(guiText.name == "Name" || guiText.name == "Key")
		{
			guiText.fontSize = Screen.height/18;
		}
		else
		{
			guiText.fontSize = Screen.height/10;
		}
		tailleFocus = guiText.fontSize + 3;
		tailleUnFocus = guiText.fontSize;
	}

	/**
     * Met le focus sur le texte rattaché à ce script
     *
     */
	public void Focus()
	{
		guiText.color = couleurFocus;
		guiText.fontSize = tailleFocus;
	}

	/**
     * Met enlève le focus sur le texte rattaché à ce script
     *
     */
	public void UnFocus()
	{
		guiText.color = couleurUnFocus;
		guiText.fontSize = tailleUnFocus;
	}
}
