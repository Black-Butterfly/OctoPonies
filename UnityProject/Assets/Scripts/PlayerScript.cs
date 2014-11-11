using UnityEngine;

public partial class PlayerScript : MonoBehaviour 
{
    private Animator animator;

    public MusicScript MS = null;
    public RailCameraScript RCS = null;
    public Vector2 speed = new Vector2(15, 25);
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
    public int score = 0;

    private Vector2 Movement;
	private float InputY;
    private bool FirstMove;
    private AttackScript ws;
	private ScoreScript ss;
	private int Direction;
	private int lastDirection;
	private bool onGround;
	private bool onWall;
	private bool onRope;
	private bool onBumper;
	public int bumperForce;
	//private int bumperAngle;
    private float modSpeed;
	private bool doJump;

    void Awake()
    {
		doJump = false;
        Movement = new Vector2(0, 0);
        FirstMove = true;
        animator = GetComponent<Animator>();
        Direction = 0;
        lastDirection = 0;
        onGround = false;
        onWall = false;
        onRope = false;
        onBumper = false;
        bumperForce = 0;
		InputY = 0;
		//bumperAngle = 0;
        modSpeed = 0;
        ws = GetComponent<AttackScript>();
		ss = GameObject.Find("ScoreText").GetComponent<ScoreScript>();
    }

	void Start()
	{
		Time.timeScale = 1.0f;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
		C_Collectible(collision);
        C_Bumper(collision, true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        C_Bumper(collision, false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        C_Block(collision, true);
        C_Trap(collision);
        C_Rope(collision, true);
		C_Destructible(collision);
		
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        C_Block(collision, false);
        C_Rope(collision, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale <= 0) return;

        CheckDirection();
        UpdateGravity();
		tryJump();
        CheckAttack();
        CheckBorders();
        CheckAnimator();
	}

	void FixedUpdate()
	{
		InputY = CalculateInputY();
		UpdateMovement (InputY);
		UpdateVelocity ();
	}

}
