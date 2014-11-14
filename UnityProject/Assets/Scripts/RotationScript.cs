/**
 * @file    RopeScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Permet de mettre en rotation un objet.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe RotationScript permet de mettre en rotation un objet.
 *
 */
public class RotationScript : MonoBehaviour {

	/** @brief rotAxis axe de rotation */
    public Vector3 rotAxis = new Vector3(0, 0, 0);
	/** @brief rotSpeed vitesse de rotation */
    public float rotSpeed = 0;
	/** @brief angle angle actuel */
    public float angle = 0;
	
	/**
	 * Appellé à chaque frame
     * Fait tourner l'objet sur lui meme.
     *
     */
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
