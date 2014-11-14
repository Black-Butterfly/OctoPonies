/**
 * @file    PlayerScript.Method.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Classe partiel de PlayerScript, contient les fonctions privee pour le joueur.
 *
 */

using UnityEngine;

/**
 * @brief La classe PlayerScript cette partie contient les fonctions privee du joueur.
 *
 */
public partial class PlayerScript
{
	/**
     * Mort du joueur, relance le niveau
     *
     */
    void Death()
    {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsJumping", false);
        animator.SetTrigger("Death");
        SpecialEffectsHelper.Instance.Explosion(transform.position);
        RCS.Reset();
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        Direction = 0;
        this.transform.localPosition = newPos;
        FirstMove = true;
        MS.StopPlaying();
        Application.LoadLevel("Lvl1");
    }

	/**
     * Surveille les bords de la caméra, si le joueur sort, il meure.
     *
     */
    void CheckBorders()
    {
        var dist = (transform.position - Camera.main.transform.position).z;

	    var leftBorder = Camera.main.ViewportToWorldPoint(
	        new Vector3(0, 0, dist)
	    ).x;

	    var rightBorder = Camera.main.ViewportToWorldPoint(
	        new Vector3(1, 0, dist)
	    ).x;

	    var topBorder = Camera.main.ViewportToWorldPoint(
	        new Vector3(0, 1, dist)
	    ).y;

	    var bottomBorder = Camera.main.ViewportToWorldPoint(
	        new Vector3(0, 0, dist)
	    ).y;
	    if (transform.position.x < leftBorder ||
	        transform.position.x > rightBorder ||
	        transform.position.y < bottomBorder ||
	        transform.position.y > topBorder) Death();
    }

	/**
     * Met à jour l'animation du joueur.
     *
     */
    void CheckAnimator()
    {
        animator.SetBool("Attacking", ws.isAttacking());
        if (!onWall)
        {
            animator.SetBool("OnWall", false);
            if (Direction != 0) this.transform.localScale = new Vector3(2 * Direction, 2, 1);
            else this.transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            animator.SetBool("OnWall", true);
            this.transform.localScale = new Vector3(2 * lastDirection, 2, 1);
        }

        animator.SetBool("IsSliding", (Input.GetButton("Slide") && onGround));

        animator.SetBool("OnRope", onRope);

        if (!onGround)
        {
            animator.SetBool("IsJumping", true);
            if (rigidbody2D.velocity.y > 0)
                animator.SetBool("IsFalling", false);
            else
                animator.SetBool("IsFalling", true);

            animator.SetBool("IsRunning", false);
        }
        else
        {
            if (Direction != 0)
            {
                animator.SetBool("IsRunning", true);
		SpecialEffectsHelper.Instance.Running(new Vector3(transform.position.x, 
				                                  transform.position.y - 1,
				                                  transform.position.z));
            }
            else animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);
        }
    }

	/**
     * Mise à jour du mouvement
     *
     */
	void UpdateMovement(float InputY)
	{
        float speedx = speed.x + modSpeed;
        float speedy = rigidbody2D.velocity.y;
        if (InputY != 0)
        {
            speedy = InputY;
        }
        Movement = new Vector2(speedx * Direction, speedy);
	}

	/**
     * Applique le mouvement
     *
     */
    void UpdateVelocity()
    {
        rigidbody2D.velocity = Movement;
    }

	/**
     * Surveille la touche attaquer
     *
     */
    void CheckAttack()
    {
        bool attack = Input.GetButtonDown("Fire1");
		if(attack)
		{
            ws.Attack(Direction);
		}
    }

	/**
     * Met à jour la gravité pour glissé plus doucement contre un mur.
     *
     */
    void UpdateGravity()
    {
        if (onWall && rigidbody2D.velocity.y < 0) this.rigidbody2D.gravityScale = 2.2f;
        else this.rigidbody2D.gravityScale = 5.0f;
    }

	/**
     * surveille la touche de saut
     *
     */
	void tryJump(){
		bool jump = Input.GetButtonDown("Jump");
		if ((jump && (onGround || onRope) && !onBumper)
		    || (jump && onWall && !onGround && !onBumper)
		    || (onBumper && onGround))
		{
			doJump = true;
		}
	}

	/**
     * Calcule le déplacement sur Y
     *
     */
    float CalculateInputY()
    {
		float inputY = 0;
		if (!doJump) return 0;

		doJump = false;

        if ((onGround || onRope) && !onBumper)
        {
			inputY = speed.y  + rigidbody2D.velocity.y;
        }
        else if (onWall && !onGround && !onBumper)
        {
            Direction = -(lastDirection);
            lastDirection = Direction;
            inputY = speed.y;
        }
        else if (onBumper && onGround)
        {
			inputY = bumperForce;
		}
        return inputY;
    }

	/**
     * Surveille l'axe horizontal
     *
     */
    void CheckDirection()
    {
        bool CanMove = Input.GetAxis("Horizontal") != 0 && onGround && !onRope && !ws.isAttacking();
        if (CanMove)
        {
            if (FirstMove)
            {
                RCS.StartMoving();
                MS.StartPlaying();
            }
            
            int newDirection = (int)(Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal")));
            if (!(onWall && lastDirection == newDirection))
            {
                lastDirection = Direction;
                Direction = newDirection;
            }
        }
    }
}