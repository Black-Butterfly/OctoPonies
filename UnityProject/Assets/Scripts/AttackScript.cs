/**
 * @file    AttackScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion de l'attaque
 *
 */

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

/**
 * @brief La classe AttackScript qui gère l'attaque.
 *
 */
public class AttackScript : MonoBehaviour
{
	/** @brief shootCooldown avant prochaine attaque */
	private float shootCooldown;
	/** @brief timeAttack durée de l'attaque, 0.2 secondes */
	public float timeAttack = 0.2f;

	/**
     * S'execute lors de la création du script.
     * Initialise le temps avant la prochaine attaque à 0.
     *
     */
	void Start()
	{
		shootCooldown = 0f;
	}

	/**
     * Lors de l'attaque, initialise le temps avant prochaine attaque.
     * On ne peut pas réattaquer avant que le temps soit écoulé, ou si nous sommes à l'arret.
     *
     * @param[in] Direction 1 ou -1 si le personnage est en mouvement, 0 à l'arret.
     *
     */
	public void Attack(int Direction)
	{
		if(shootCooldown <= 0f && Direction != 0)
		{
			shootCooldown = timeAttack;
		}
	}

	/**
     * @return Renvoie vrai si le temps n'est pas écoulé (attaque en cours), sinon faux.
     *
     */
	public bool isAttacking()
	{
		return shootCooldown > 0f;
	}

	/**
     * Appellé à chaque frame.
     * Met à jour le temps restant.
     *
     */
	void FixedUpdate()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
}