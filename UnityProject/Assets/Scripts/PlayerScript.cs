/**
 * @file    PlayerScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Classe partiel de PlayerScript, contient les données membres, les initialisations et appels de fonction.
 *
 */

using UnityEngine;

/**
 * @brief La classe PlayerScript cette partie gère données membres, les initialisations et appels de fonction.
 *
 */
public partial class PlayerScript : MonoBehaviour 
{
	/** @brief animator contiendra l'animator du personnage */
    private Animator animator;

	/** @brief MS contiendra le script pour géré la musique */
    public MusicScript MS = null;
	/** @brief ms contiendra le script pour géré la caméra */
    public RailCameraScript RCS = null;
	/** @brief speed contient le vecteur vitesse du personnage */
    public Vector2 speed = new Vector2(15, 25);
	/** @brief CheckPoint contient un checkpoint pour la mort et les futurs checkpoints */
    public Vector3 CheckPoint = new Vector3(-14, 2, 0);
	/** @brief score contient le score */
    public int score = 0;

	/** @brief Movement contient le vecteur mouvement du personnage */
    private Vector2 Movement;
	/** @brief InputY contient la valeur d'input de l'axe Y */
	private float InputY;
	/** @brief FirstMove permet de lancer la musique au 1er mouvement */
    private bool FirstMove;
	/** @brief ws contiendra le script pour géré l'attaque */
    private AttackScript ws;
	/** @brief ss contiendra le script pour géré l'affichage score */
	private ScoreScript ss;
	/** @brief Direction 1 vers la droite, -1 vers la gauche */
	private int Direction;
	/** @brief lastDirection retient la dernière direction lors d'un arret */
	private int lastDirection;

	/** @brief onGround true = au sol */
	private bool onGround;
	/** @brief onWall true = contre un mur */
	private bool onWall;
	/** @brief onRope true = sur une corde */
	private bool onRope;
	/** @brief onBumper true = sur un bumper */
	private bool onBumper;

	/** @brief bumperForce contient la force de bump */
	public int bumperForce;
	/** @brief Not implemented yet */
	//private int bumperAngle;
	/** @brief modSpeed modificateur de la vitesse */
    private float modSpeed;
	/** @brief doJump faire un saut */
	private bool doJump;

	/**
     * S'execute lors de la création du script.
     * Initialise les variables.
     *
     */
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

	/**
     * S'execute lors de la création du script.
     * Vitesse du jeu = 1
     *
     */
	void Start()
	{
		Time.timeScale = 1.0f;
	}

	/**
     * S'execute lors de la collision avec un objet marqué trigger
     *
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
		C_Collectible(collision);
        C_Bumper(collision, true);
    }

	/**
     * S'execute en sortant de la collision avec un objet marqué trigger
     *
     */
    void OnTriggerExit2D(Collider2D collision)
    {
        C_Bumper(collision, false);
    }

	/**
     * S'execute lors de la collision avec un objet non trigger
     *
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        C_Block(collision, true);
        C_Trap(collision);
        C_Rope(collision, true);
		C_Destructible(collision);
		
    }

	/**
     * S'execute en sortant de la collision avec un objet non trigger
     *
     */
    void OnCollisionExit2D(Collision2D collision)
    {
        C_Block(collision, false);
        C_Rope(collision, false);
    }

	/**
	 * Appellé à chaque frame
     * Vérification et mise à jour player
     *
     */
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

	/**
	 * Appellé à chaque frame
     * Vérification et mise à jour player
     *
     */
	void FixedUpdate()
	{
		InputY = CalculateInputY();
		UpdateMovement (InputY);
		UpdateVelocity ();
	}

}
