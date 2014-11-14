/**
 * @file    PlayerScript.Public.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Classe partiel de PlayerScript, contient les fonctions public pour le joueur.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe PlayerScript cette partie contient les fonctions public du joueur.
 *
 */
public partial class PlayerScript
{
	/**
 	* Direction de la transphormation pour les cheveux
 	*
 	*/
    public int getScaleFactor()
    {
       return ((int) (this.transform.localScale.x / 2));
    }
}
