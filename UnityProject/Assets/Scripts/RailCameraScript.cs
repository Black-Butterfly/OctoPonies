using UnityEngine;
using System.Collections;

public class RailCameraScript : MonoBehaviour {
    public PathNode firstNode = null; //modif à chaque checkpoint
    public float Speed = 0;
    private PathNode next = null; //modif à chaque node
    private bool isMoving = false;

    public void StartMoving() { isMoving = true; }

    public void Reset(Vector3 CheckPoint) {
        isMoving = false;
        next = firstNode;
        Vector3 newPos = new Vector3(CheckPoint.x, CheckPoint.y, CheckPoint.z - 15);
        this.transform.localPosition = newPos;
    }
	// Use this for initialization
	void Start () {
	    next = firstNode;
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
            this.next = next.nextNode;
        float step = Speed * Time.deltaTime;
        this.transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            next.transform.localPosition, step);
	}
}
