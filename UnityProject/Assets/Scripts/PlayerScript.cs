using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 1, 0);
    private int Direction = 0;
    private Vector2 movement;
    private bool onGround = false;
	
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
            Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
            Direction = 0;
            this.transform.localPosition = newPos;
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
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetAxis("Horizontal") != 0) 
        {
            Direction = (int)(Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal")));
        }
        CameraScript cs = this.GetComponentInChildren<CameraScript>();
        cs.playerDirection = Direction;
        float inputY = 0;
        bool jump = Input.GetButtonDown("Jump");
        
        if (jump && onGround)
        {
            inputY = 1;
        }
        
        movement = new Vector2(speed.x * Direction, (speed.y * inputY ) + rigidbody2D.velocity.y);
	}
    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }
}
