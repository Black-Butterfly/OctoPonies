/**
 * @file    UpdateScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion du menu de pause.
 *
 */

using UnityEngine;
using System.Collections;

/**
 * @brief La classe vide UpdateScript.
 *
 */
public class UpdateScript : MonoBehaviour {

	/**
	 * Appellé à chaque frame
     * Surveille la mise en pause et fait apparaitre le menu pause si il faut ou le surprime.
     *
     */
	void Update () {
		if(Input.GetButtonDown("Pause")) {
			if(Time.timeScale > 0.0f)
			{
				Time.timeScale = 0.0f;
				AudioListener.pause = true;
				this.transform.GetChild(0).gameObject.SetActive(true);
				this.transform.GetChild(0).gameObject.AddComponent<PauseMenuScript>();
			}
			else
			{
				Time.timeScale = 1.0f;
				AudioListener.pause = false;
				this.transform.GetChild(0).gameObject.SetActive(false);
				Destroy(this.GetComponentInChildren<PauseMenuScript>());
			}
		}
	}
}
