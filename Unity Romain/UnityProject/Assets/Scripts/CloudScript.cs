using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

    public int nbCloud;

    public GameObject Cloud1;
    public GameObject Cloud2;
    public GameObject Cloud3;

    public float xMin, xMax, yMin, yMax;
	// Use this for initialization
	void Start () {
        GameObject[] Prefabs = new GameObject[3];
        Prefabs[0] = Cloud1;
        Prefabs[1] = Cloud2;
        Prefabs[2] = Cloud3;

        for (int i = 0; i < nbCloud; ++i)
        {
            int nCloud = Random.Range(0, 3);
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);

            Vector3 Pos = new Vector3(x, y, 0);
            var c = Instantiate(Prefabs[nCloud]) as GameObject;
            c.transform.parent = transform;
            c.transform.localPosition = Pos;
            c.renderer.sortingLayerName = renderer.sortingLayerName;
            c.renderer.sortingOrder = 200;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
