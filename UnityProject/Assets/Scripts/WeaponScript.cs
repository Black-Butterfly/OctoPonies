/**
 * @file    WeaponScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion de l'arme.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe WeaponScript gère l'arme.
 *
 */
public class WeaponScript : MonoBehaviour {

	/**
	 * Detruit le destructible si l'arme le touche.
	 * 
	 */
	void OnTriggerEnter2D(Collider2D  collision)
	{
		DestructibleScript CS = collision.gameObject.GetComponent<DestructibleScript>();
		if (CS != null)
		{
			Destroy(collision.gameObject);
		}
	}
}
