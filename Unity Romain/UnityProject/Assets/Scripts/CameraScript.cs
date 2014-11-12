using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float playerDirection = 1;
    private double xMod = 1;
    private double step = 0.1;
    private float xBase = 7;
    private float yBase = (float)1.5;
    private float zBase = -15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (xMod > (double)playerDirection) xMod -= step;
        if (xMod < (double)playerDirection) xMod += step;

        Vector3 localPos = new Vector3((float)(xMod * xBase), yBase, zBase);
        this.transform.localPosition = localPos;

	}
}
