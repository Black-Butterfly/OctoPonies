using UnityEngine;
using System.Collections;

public class RailCameraScript : MonoBehaviour {
    public PathNode firstNode = null; //modif à chaque checkpoint
    public float Speed;
    private PathNode next = null; //modif à chaque node
    private bool isMoving = false;
    private Vector3 CheckPoint;
    public void StartMoving() { isMoving = true; }
	private PlayerScript ps;
	public float MaxToBorder = 2;
	private Vector2 down = new Vector2(0, -1);
    public float angle = 0;
    public void Reset() {
        isMoving = false;
        next = firstNode;
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        this.transform.localPosition = newPos;
        Speed = 15;

    }
	// Use this for initialization
	void Start () {
        /*A virer*/
        transform.position = firstNode.transform.position;
        /*Fin a virer*/
		ps = GameObject.Find ("Player").GetComponent<PlayerScript> ();
	    next = firstNode;
        Speed = 15;
        CheckPoint = transform.localPosition;
	}

	float distToBorder(){
		float dist = (ps.transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		return ps.transform.position.x - leftBorder; 
	}

	// Update is called once per frame
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
