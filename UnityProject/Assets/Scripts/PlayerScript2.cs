using UnityEngine;

public class PlayerScript2 : MonoBehaviour 
{
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
    public float deathY = -5;
    public int Direction = 0;
	public int lastDirection = 0;
    private Vector2 movement;
    public bool onGround = false;
	public bool onWall = false;
	
    void Death()
    {
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        Direction = 0;
        this.transform.localPosition = newPos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
		Vector2 hit = collision.contacts[0].normal;

		float angle = Vector2.Angle(hit, Vector2.right);
		
		if (Mathf.Approximately(angle, 0) || Mathf.Approximately(angle, 180)) { // Gauche ou droite
			onWall = true;
			Direction = 0;
		}
		if (Mathf.Approximately(angle, 90)) { // Bas
			onGround = true;
			this.rigidbody2D.gravityScale = 5;
		}
	}
    void OnCollisionExit2D(Collision2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
			if((rigidbody2D.velocity.x == 0 && rigidbody2D.velocity.y != 0 && !onGround) || rigidbody2D.velocity.x != 0)
				onWall = false;
			if(rigidbody2D.velocity.y != 0)
				onGround = false;
        }
    }
	// Update is called once per frame
	void Update () 
    {
		AttackScript ws = this.GetComponent<AttackScript>();

        if (Input.GetAxis("Horizontal") != 0 && onGround && !ws.isAttacking()) 
        {
			int newDirection = (int)(Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal")));
			if(!(onWall && lastDirection == newDirection))
			{
				lastDirection = Direction;
				Direction = newDirection;
			}
        }
        CameraScript cs = this.GetComponentInChildren<CameraScript>();
        //cs.playerDirection = Direction;

		if(onWall && rigidbody2D.velocity.y < 0) this.rigidbody2D.gravityScale = 2.2f;

        float inputY = 0;
        bool jump = Input.GetButtonDown("Jump");
        
        if (jump && onGround)
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

		bool attack = Input.GetButtonDown("Fire1");
		if(attack)
		{
			ws.Attack(Direction);
		}

        if (this.transform.localPosition.y < deathY) Death();

        movement = new Vector2(speed.x * Direction, inputY + rigidbody2D.velocity.y);
		rigidbody2D.velocity = movement;
	}
    void FixedUpdate()
    {
        
    }
}
