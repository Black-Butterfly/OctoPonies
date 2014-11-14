/**
 * @file    BumperScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion du Bumper.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe BumperScript gère le bumper.
 *
 */
public class BumperScript : MonoBehaviour
{
	/** @brief bumperForce force du bumper, par défaut 25 */
    public int bumperForce = 25;
	/** @brief Animator animator du bumper */
	private Animator animator;

	/**
     * S'execute lors de la création du script.
     * Initialise l'animator enrecupérant l'animator de l'objet lié au script.
     *
     */
	void Start(){
		animator = GetComponent<Animator>();
	}

	/**
     * Lance l'animation.
     *
     */
    public void Bump()
    {
		animator.SetTrigger("Bump");
    }
}
