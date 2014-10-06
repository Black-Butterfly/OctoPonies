using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    public RailCameraScript RCS = null;
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
    public float deathY = -5;
    private int Direction = 0;
    private int lastDirection = 0;
    private Vector2 movement;
    public bool onGround = false;
    public bool onWall = false;

    void Death()
    {
        RCS.Reset();
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        Direction = 0;
        this.transform.localPosition = newPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
            lastDirection = Direction;
            Direction = 0;
            onWall = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
            onGround = true;
        }
        TrapScript TS = collision.gameObject.GetComponent<TrapScript>();
        if (TS != null)
        {
            Death();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
            onGround = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
            onWall = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && onGround)
        {
            RCS.StartMoving();
            int newDirection = (int)(Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal")));
            if (!(onWall && lastDirection == newDirection))
                Direction = newDirection;
        }
        float inputY = 0;
        bool jump = Input.GetButtonDown("Jump");

        if (jump && onGround)
        {
            inputY = 1;
        }
        else if (jump && onWall && !onGround)
        {
            Direction = -(lastDirection);
            inputY = 1.1f;
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

        movement = new Vector2(speed.x * Direction, (speed.y * inputY) + rigidbody2D.velocity.y);
        rigidbody2D.velocity = movement;
    }

    void FixedUpdate()
    {
        
    }
}
