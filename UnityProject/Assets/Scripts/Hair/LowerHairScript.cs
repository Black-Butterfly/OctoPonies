using UnityEngine;
using System.Collections;

public class LowerHairScript : MonoBehaviour {
	public float x, y;
    public int xDir;
    public int yDir;
	public int rnd;
	// Use this for initialization
	void Awake () {
		x = transform.localPosition.x;
		y = transform.localPosition.y;
        xDir = 1;
        yDir = 1;
	}
	
    private void tryChange(float x, float y)
    {
        if (x > 0.33f) xDir = -1;
        else if (x < 0.25f) xDir = 1;
        
        if (y > 0.27f) yDir = -1;
        else if (y < 0.18f) yDir = 1;
    }

	// Update is called once per frame
	void Update () 
	{
		rnd = Random.Range (-10, 50);
		x += (xDir * rnd) / 10000f;
		y += (yDir * rnd) / 10000f;
		//transform.position = transform.localToWorldMatrix.MultiplyPoint(new Vector3(x, y, 0));
		transform.localPosition = new Vector3(x, y, 0);

        tryChange(x, y);
	}
}
