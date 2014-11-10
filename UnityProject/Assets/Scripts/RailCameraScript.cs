using UnityEngine;
using System.Collections;

public class RailCameraScript : MonoBehaviour {
    public PathNode firstNode = null; //modif à chaque checkpoint
    private float Speed;
    private PathNode next = null; //modif à chaque node
    private bool isMoving = false;
    private Vector3 CheckPoint;
    public void StartMoving() { isMoving = true; }
	private PlayerScript ps;

    public void Reset() {
        isMoving = false;
        next = firstNode;
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z);
        this.transform.localPosition = newPos;
        Speed = next.SpeedToThis;

    }
	// Use this for initialization
	void Start () {
	    next = firstNode;
        Speed = next.SpeedToThis;
        CheckPoint = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
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
            Speed = next.SpeedToThis;
        }
        float step = Speed * Time.deltaTime;
        this.transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            next.transform.localPosition, step);
	}
}
