﻿using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
    public float deathY = -5;
    private int Direction = 0;
    private Vector2 movement;
    public bool onGround = false;

    void Death()
    {
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        Direction = 0;
        this.transform.localPosition = newPos;
    }
    /*
    void OnTriggerEnter2D(Collider2D collision){
        BlockScript BS = collision.gameObject.GetComponent<BlockScript>();
        if (BS != null)
        {
               Direction = 0;
        }
    }*/

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

        if (this.transform.localPosition.y < deathY) Death();

        movement = new Vector2(speed.x * Direction, (speed.y * inputY ) + rigidbody2D.velocity.y);
	}
    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }
}