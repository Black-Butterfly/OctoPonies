/**
 * @file    RopeScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Sert à detecter la corde.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe RopeScript sert à detecter la corde et possède des paramètres pour le joueur.
 *
 */
public class RopeScript : MonoBehaviour {

	/** @brief ropeDirection direction de la corde */
    public int ropeDirection = 0;
	/** @brief modSpeed modification de vitesse du player */
    public int modSpeed = 0;
}
