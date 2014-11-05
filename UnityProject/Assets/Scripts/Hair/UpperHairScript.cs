using UnityEngine;

public class UpperHairScript : MonoBehaviour {
    private PlayerScript ps;
    private Vector3 rotAxis = new Vector3(0, 0, 1);
    private float scaleDir;
    private Vector2 down = new Vector2(0, -1);
	// Use this for initialization
	void Awake () {
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
        scaleDir = -1;
	}

    private void tryChange(float scale)
    {
        if (scale < 0.5f) scaleDir = 1;
        else if(scale > 1.2f) scaleDir = -1;
    }

    private float processAngle(float a)
    {
        return Mathf.Clamp(a - 90f, -90, 40);
    }

	// Update is called once per frame
	void Update () {
        float angle = processAngle(Vector2.Angle(ps.rigidbody2D.velocity, down));
        transform.localRotation = Quaternion.AngleAxis(angle, rotAxis);
        float scale = transform.localScale.x + ((scaleDir * Random.Range(-10, 50)) / 100);
        transform.localScale = new Vector3(scale, 1, 1);
        tryChange(scale);
	}
}
