/**
 * @file    ForestScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Génère des arbres et des forets de façon aléatoire.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe ForestScript génère des arbres avec des montagnes.
 *
 */
public class ForestScript : MonoBehaviour {

	/** @brief nbArbres nombre de nuage généré, réglé dans Unity */
    public int nbArbres;
	/** @brief Tree1 texture du nuage, donnée dans Unity */
    public GameObject Tree1;
	/** @brief Tree2 texture du nuage, donnée dans Unity */
    public GameObject Tree2;
	/** @brief Tree3 texture du nuage, donnée dans Unity */
    public GameObject Tree3;

	/** @brief nbMountain nombre de nuage généré, réglé dans Unity */
    public int nbMountain;
	/** @brief Mountain texture du nuage, donnée dans Unity */
    public GameObject Mountain;

	/** @brief xMin, xMax, yMin, yMax coordonnée dans lesquel la foret sont générés, , réglé dans Unity */
    public float xMin, xMax, yMin, yMax;

	/**
     * S'execute lors de la création du script.
     * Initialise les variables et génère de façon aléatoire la foret d'arbres et de montagnes.
     *
     */
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
            GameObject c = Instantiate(Mountain) as GameObject;
            c.transform.parent = transform;
            c.transform.localPosition = Pos;
            c.renderer.sortingLayerName = renderer.sortingLayerName;
            c.renderer.sortingOrder = renderer.sortingOrder + 10 - (int)y;
        }
	}
}
