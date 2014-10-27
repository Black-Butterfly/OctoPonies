using UnityEngine;

public partial class PlayerScript
{
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
        Application.LoadLevel(0);
    }

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

    void CheckAnimator()
    {
        if (Direction != 0) this.transform.localScale = new Vector3(2 * Direction, 2, 1);
        else this.transform.localScale = new Vector3(2, 2, 1);

        if (Input.GetButton("Slide") && onGround)
        {
            animator.SetBool("IsSliding", true);
        }
        else animator.SetBool("IsSliding", false);

        if (!onGround)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsRunning", false);
        }
        else
        {
            if (Direction != 0) animator.SetBool("IsRunning", true);
            animator.SetBool("IsJumping", false);
        }
    }

    void UpdateMovement(float InputY)
    {
        float speedx = speed.x + modSpeed;
        rigidbody2D.velocity = new Vector2(speedx * Direction, InputY + rigidbody2D.velocity.y);
    }

    void CheckAttack()
    {
        bool attack = Input.GetButtonDown("Fire1");
		if(attack)
		{
			ws.Attack(Direction);
		}
    }

    void UpdateGravity()
    {
        if (onWall && rigidbody2D.velocity.y < 0) this.rigidbody2D.gravityScale = 2.2f;
        else this.rigidbody2D.gravityScale = 5.0f;
    }

    float CalculateInputY()
    {
        float inputY = 0;
        bool jump = Input.GetButtonDown("Jump");

        if (jump && (onGround || onRope))
        {
            inputY = speed.y * 1;
        }
        else if (jump && onWall && !onGround)
        {
            Direction = -(lastDirection);
            lastDirection = Direction;
            inputY = (speed.y * 1) - rigidbody2D.velocity.y;
        }
        else if (onBumper)
        {
            inputY = bumperForce - rigidbody2D.velocity.y;
        }

        return inputY;
    }

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