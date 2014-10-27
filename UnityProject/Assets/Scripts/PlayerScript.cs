using UnityEngine;

public partial class PlayerScript : MonoBehaviour 
{
    private Animator animator;

    public MusicScript MS = null;
    public RailCameraScript RCS = null;
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
    public int score = 0;

    private bool FirstMove;
    private AttackScript ws;
    private int Direction;
    private int lastDirection;
    private bool onGround;
    private bool onWall;
    private bool onRope;
	private bool onBumper;
	private int bumperForce;
    private float modSpeed;

    void Awake()
    {
        FirstMove = true;
        animator = GetComponent<Animator>();
        Direction = 0;
        lastDirection = 0;
        onGround = false;
        onWall = false;
        onRope = false;
        onBumper = false;
        bumperForce = 0;
        modSpeed = 0;
        ws = GetComponent<AttackScript>();
    }

	void Start()
	{
		Time.timeScale = 1.0f;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        C_Collectible(collision);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        C_Block(collision, true);
        C_Trap(collision);
        C_Rope(collision, true);
        C_Bumper(collision, true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        C_Block(collision, false);
        C_Rope(collision, false);
        C_Bumper(collision, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale <= 0) return;

        CheckDirection();
        UpdateGravity();
        float InputY = CalculateInputY();
        CheckAttack();
        CheckBorders();
        CheckAnimator();
        UpdateMovement(InputY);
	    
	}
}
