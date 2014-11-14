/**
 * @file    ScoreScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion de l'affichage du score.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe ScoreScript gère l'affichage du score.
 *
 */
public class ScoreScript : MonoBehaviour {

	/**
     * S'execute lors de la création du script.
     * Règle la taille d'affichage du score en fonction de l'écran.
     *
     */
	void Awake()
	{
		guiText.fontSize = Screen.height / 8;
	}

	/**
     * Mettra à jour le score lors de l'appel
     *
     */
	public void UpdateScore(int Score)
	{
		guiText.text = "Score : " + Score.ToString();
	}
}
