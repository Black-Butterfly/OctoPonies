/**
 * @file    RailCameraScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion de la caméra sur rail.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe RailCameraScript gère la camera sur rail.
 *
 */
public class RailCameraScript : MonoBehaviour {

	/** @brief firstNode contient le 1er noeud du chemin */
    public PathNode firstNode = null; //modif à chaque checkpoint
	/** @brief Speed vitesse de la camera */
    public float Speed;
	/** @brief firstNode contient le noeud du chemin vers lequel la camera va */
    private PathNode next = null; //modif à chaque node
	/** @brief isMoving true la camera bouge, false immobile */
    private bool isMoving = false;
	/** @brief CheckPoint coordonnée du checkpoint */
    private Vector3 CheckPoint;
	/** @brief ps contient le script du joueur */
	private PlayerScript ps;
	/** @brief MaxToBorder distance max par rapport au joueur (not used)*/
	public float MaxToBorder = 2;
	/** @brief down vecteur vertical */
	private Vector2 down = new Vector2(0, -1);
	/** @brief angle contiendra l'angle */
    public float angle = 0;

	/**
     * Lance la camera
     *
     */
	public void StartMoving()
	{
		isMoving = true;
	}

	/**
     * Reset la camera
     *
     */
    public void Reset()
	{
        isMoving = false;
        next = firstNode;
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        this.transform.localPosition = newPos;
        Speed = 15;

    }

	/**
     * S'execute lors de la création du script.
     * Initialisation de la camera.
     *
     */
	void Start () {
        /*A virer* /
        transform.position = firstNode.transform.position;
        /*Fin a virer*/
		ps = GameObject.Find ("Player").GetComponent<PlayerScript> ();
	    next = firstNode;
        Speed = 15;
        CheckPoint = transform.localPosition;
	}

	/**
     * Distance par rapport au bord de la camera
     *
     */
	float distToBorder(){
		float dist = (ps.transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		return ps.transform.position.x - leftBorder; 
	}

	/**
	 * Appellé à chaque frame
     * Gère le déplacement de la caméra
     *
     */
	void FixedUpdate () {
        if (next == null || !isMoving) return;

        float x, y, z;
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        z = transform.localPosition.z;

        if (Mathf.Abs(x) == Mathf.Abs(next.transform.localPosition.x)
            && Mathf.Abs(y) == Mathf.Abs(next.transform.localPosition.y)
            && Mathf.Abs(z) == Mathf.Abs(next.transform.localPosition.z))
        {
            this.next = next.nextNode;
        }
		Vector2 from = new Vector2 (next.transform.position.x, next.transform.position.y);
		Vector2 to = new Vector2 (this.transform.position.x, this.transform.position.y);
		Vector2 mov = new Vector2 (from.x- to.x, from.y - to.y);
		angle = Vector2.Angle (mov.normalized, down);

		float playerSpeed = ps.rigidbody2D.velocity.x;
		if (playerSpeed != 0)
			Speed = playerSpeed;
		if ((angle >= 0 && angle < 45) || (angle >= 315)) 
        {
            Speed = Mathf.Max(Mathf.Abs(ps.rigidbody2D.velocity.y), Speed);
		}
		float modSpeed = 0;
		float toBorder = distToBorder ();
		if (toBorder > 2f)
			modSpeed = 4;

        Speed = Mathf.Abs(Speed);

        float step = (Speed + modSpeed) * Time.deltaTime;

        this.transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            next.transform.localPosition, step);
	}
}
