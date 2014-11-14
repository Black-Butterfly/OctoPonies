/**
 * @file    CloudScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Génère des nuages de façon aléatoire.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe CloudScript génère les nuages.
 *
 */
public class CloudScript : MonoBehaviour {

	/** @brief nbCloud nombre de nuage généré, réglé dans Unity */
    public int nbCloud;
	/** @brief Cloud1 texture du nuage, donnée dans Unity */
    public GameObject Cloud1;
	/** @brief Cloud2 texture du nuage, donnée dans Unity */
    public GameObject Cloud2;
	/** @brief Cloud3 texture du nuage, donnée dans Unity */
    public GameObject Cloud3;
	/** @brief xMin, xMax, yMin, yMax coordonnée dans lesquel les nuages sont générés, , réglé dans Unity */
    public float xMin, xMax, yMin, yMax;

	/**
     * S'execute lors de la création du script.
     * Initialise les variables et génère de façon aléatoire les nuages.
     *
     */
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
}
