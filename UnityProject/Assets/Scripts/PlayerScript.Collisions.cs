/**
 * @file    PlayerScript.Collision.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Classe partiel de PlayerScript, gestion des collisions.
 *
 */

using UnityEngine;

/**
 * @brief La classe PlayerScript cette partie gère les collisions.
 *
 */
public partial class PlayerScript
{
	/**
     * Gestion de la collision avec un collectible.
     * Augmente le score, détruit le collectible avec effet de particule.
     * 
     * @param[in] collision contient la collision.
     *
     */
    void C_Collectible(Collider2D collision)
    {
        CollectibleScript CS = collision.gameObject.GetComponent<CollectibleScript>();
        if (CS == null) return;

        score += CS.value;
		ss.UpdateScore(score);
		Destroy(collision.gameObject);
		ParticuleScript.Instance.Collect(transform.position);
	}

	/**
     * Gestion de la collision avec un block.
     * Change les variables en fonction du coté de collision ou en sortie de collision.
     *
     * @param[in] collision contient la collision.
     * @param[in] Enter true entre en collsion, false sort de colision.
     *
     */
	void C_Block(Collision2D collision, bool Enter)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS == null) return;
        if (Enter)
        {
            Vector2 hit = collision.contacts[0].normal;
            float angle = Vector2.Angle(hit, Vector2.right);
            if (Mathf.Approximately(angle, 0) || Mathf.Approximately(angle, 180))
            { // Gauche (0) ou Droite (180)
                onWall = true;
                Direction = 0;
            }
            if (Mathf.Approximately(angle, 90))
            { // Bas
                onGround = true;
                this.rigidbody2D.gravityScale = 5;
            }
        }
        else
        {
            if ((rigidbody2D.velocity.x == 0 && rigidbody2D.velocity.y != 0 && !onGround)
                || rigidbody2D.velocity.x != 0)
                onWall = false;
            if (rigidbody2D.velocity.y != 0)
                onGround = false;
        }
    }

	/**
     * Gestion de la collision avec un block.
     * Tue le personnage si il touche un piege.
     *
     * @param[in] collision contient la collision.
     *
     */
    void C_Trap(Collision2D collision)
    {
        TrapScript TS = collision.gameObject.GetComponent<TrapScript>();
        if (TS == null) return;

        Death();
    }

	/**
     * Gestion de la collision avec un block.
     * Change les variables en glissant le long d'une corde ou en la quittant.
     *
     * @param[in] collision contient la collision.
     * @param[in] Enter true entre en collsion, false sort de colision.
     *
     */
    void C_Rope(Collision2D collision, bool Enter) 
    { 
        RopeScript RS = collision.gameObject.GetComponent<RopeScript>();
        if (RS == null) return;

        if (Enter)
        {
            onRope = true;
            modSpeed = RS.modSpeed;
            Direction = RS.ropeDirection;
        }
        else
        {
            onRope = false;
            modSpeed = 0;
        }
    }

	/**
     * Gestion de la collision avec un block.
     * Si on entre en contact avec un destructible il nous arrete.
     *
     * @param[in] collision contient la collision.
     *
     */
	void C_Destructible(Collision2D collision) 
	{ 
		DestructibleScript DS = collision.gameObject.GetComponent<DestructibleScript>();
		if (DS == null) return;

		Vector2 hit = collision.contacts[0].normal;
		float angle = Vector2.Angle(hit, Vector2.right);
		if (Mathf.Approximately(angle, 0) || Mathf.Approximately(angle, 180))
		{ // Gauche (0) ou Droite (180)
			Direction = 0;
		}
	}

	/**
     * Gestion de la collision avec un block.
     * Change les variables lorsqu'on touche un bumper ou qu'on le quitte.
     *
     * @param[in] collision contient la collision.
     * @param[in] Enter true entre en collsion, false sort de colision.
     *
     */
    void C_Bumper(Collider2D collision, bool Enter)
    {
        BumperScript BpS = collision.gameObject.GetComponent<BumperScript>();
        if (BpS == null) return;

        if (Enter)
        {
			BpS.Bump();
            //Vector2 bump = collision.contacts[0].normal;
            //float angleBumper = Vector2.Angle(bump, Vector2.right);
            //if (Mathf.Approximately(angleBumper, 90)) //Bas
            {
                onBumper = true;
                bumperForce = BpS.bumperForce;
            }
        }
        else
        {
            onBumper = false;
            modSpeed = 0;
        }
    }
}