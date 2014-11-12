using UnityEngine;
using System.Collections;

public class ForestScript : MonoBehaviour {
    public int nbArbres;
    public GameObject Tree1;
    public GameObject Tree2;
    public GameObject Tree3;

    public int nbMountain;
    public GameObject Mountain;

    public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {

        GameObject[] Prefabs = new GameObject[3];
        Prefabs[0] = Tree1;
        Prefabs[1] = Tree2;
        Prefabs[2] = Tree3;

        for (int i = 0; i < nbArbres; ++i)
        {
            int nTree = Random.Range(0, 3);
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);

            Vector3 Pos = new Vector3(x, y, 0.04788274f);
            var c = Instantiate(Prefabs[nTree]) as GameObject;
            c.transform.parent = transform;
            c.transform.localPosition = Pos;
            c.renderer.sortingLayerName = renderer.sortingLayerName;
            c.renderer.sortingOrder = renderer.sortingOrder + 10 - (int) y;
        }

        for (int i = 0; i < nbMountain; ++i)
        {
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);
            Vector3 Pos = new Vector3(x, y, 0);
            var c = Instantiate(Mountain) as GameObject;
            c.transform.parent = transform;
            c.transform.localPosition = Pos;
            c.renderer.sortingLayerName = renderer.sortingLayerName;
            c.renderer.sortingOrder = renderer.sortingOrder + 10 - (int)y;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
