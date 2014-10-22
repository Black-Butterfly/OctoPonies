using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    public RailCameraScript RCS = null;
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
    public int score = 0;
    private int Direction = 0;
    private int lastDirection = 0;
    private Vector2 movement;
    private bool onGround = false;
    private bool onWall = false;
    public bool onRope = false;
	private bool onBumper = false;
	private int bumperForce = 0;
    public float modSpeed = 0;

    void Death()
	{
		SpecialEffectsHelper.Instance.Explosion(transform.position);
        RCS.Reset();
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        Direction = 0;
        this.transform.localPosition = newPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CollectibleScript CS = collision.gameObject.GetComponent<CollectibleScript>();
        if (CS != null)
        {
            score += CS.value;
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
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
        TrapScript TS = collision.gameObject.GetComponent<TrapScript>();
        if (TS != null)
        {
            Death();
        }
        RopeScript RS = collision.gameObject.GetComponent<RopeScript>();
        if (RS != null)
        {
            onRope = true;
            modSpeed = RS.modSpeed;
            Direction = RS.ropeDirection;
        }
		BumperScript BpS = collision.gameObject.GetComponent<BumperScript>();
		if (BpS != null)
		{
			Vector2 bump = collision.contacts[0].normal;
			
			float angleBumper = Vector2.Angle(bump, Vector2.up);

			if (Mathf.Approximately(angleBumper, 0) || Mathf.Approximately(angleBumper, 180))
			{ // Gauche (0) ou Droite (180)
				onBumper = true;
				bumperForce = BpS.bumperForce;
			}
		}
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
            if ((rigidbody2D.velocity.x == 0 && rigidbody2D.velocity.y != 0 && !onGround)
                || rigidbody2D.velocity.x != 0)
                onWall = false;
            if (rigidbody2D.velocity.y != 0)
                onGround = false;
        }
        RopeScript RS = collision.gameObject.GetComponent<RopeScript>();
        if (RS != null)
        {
            onRope = false;
            modSpeed = 0;
        }
		BumperScript BpS = collision.gameObject.GetComponent<BumperScript>();
		if (BpS != null)
		{
			onBumper = false;
			modSpeed = 0;
		}
    }
    // Update is called once per frame
    void Update()
    {
		if(Time.timeScale > 0)
		{
			AttackScript ws = this.GetComponent<AttackScript>();

			if (Input.GetAxis("Horizontal") != 0 && onGround && !onRope && !ws.isAttacking())
	        {
	            RCS.StartMoving();
	            int newDirection = (int)(Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal")));
	            if (!(onWall && lastDirection == newDirection))
	            {
	                lastDirection = Direction;
	                Direction = newDirection;
	            }
	        }

			if(onWall && rigidbody2D.velocity.y < 0) this.rigidbody2D.gravityScale = 2.2f;

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
				this.rigidbody2D.gravityScale = 5;
	        }

			/****/

			else if(onBumper)
			{
				inputY = bumperForce - rigidbody2D.velocity.y;
			}

			/****/

			bool attack = Input.GetButtonDown("Fire1");
			if(attack)
			{
				ws.Attack(Direction);
			}

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
	        float speedx = speed.x + modSpeed;
	        movement = new Vector2(speed.x * Direction, inputY + rigidbody2D.velocity.y);
	        rigidbody2D.velocity = movement;
	    }
	}
}
