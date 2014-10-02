using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    public Vector2 speed = new Vector2(10, 20);
    private Vector2 movement;
    bool onGround = false;
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
            onGround = true;
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
        float inputX = Input.GetAxis("Horizontal");
        float inputY = 0;
        bool jump = Input.GetButtonDown("Jump");
        
        if (jump && onGround)
        {
            inputY = 1;
        }
        
        movement = new Vector2(speed.x * inputX, (speed.y * inputY ) + rigidbody2D.velocity.y);
	}
    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }
}
