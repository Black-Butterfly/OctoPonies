using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
    public Vector3 rotAxis = new Vector3(0, 0, 0);
    public float rotSpeed = 0;
    public float angle = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
        float newz = (rotSpeeds.z + transform.localRotation.z) % (float)180.0;
        float newx = (rotSpeeds.x + transform.localRotation.x) % (float)180.0;
        float newy = (rotSpeeds.y + transform.localRotation.y) % (float)180.0;
        if (newz >= (float)179.000) newz = 0;
        transform.localRotation = new Quaternion(newx, newy, newz, transform.localRotation.w);*/
        angle = (angle +  rotSpeed) % 360;
        transform.localRotation = Quaternion.AngleAxis(angle,rotAxis);
	}
}
