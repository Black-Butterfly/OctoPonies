/**
 * @file    MusicScript.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gère la musique.
 *
 */

using UnityEngine;

/**
 * @brief La classe MusicScript gère la musique.
 *
 */
public class MusicScript : MonoBehaviour
{
	/** @brief IsPlaying la musique est en cours de lecture */
    private bool IsPlaying;
	/** @brief offset décalage de la musique pour supprimer le blanc au début */
    public float offset = 1.5f;

	/**
     * S'execute lors de la création du script.
     * Initialise les variables.
     *
     */
    void Awake()
    {
        IsPlaying = false;
        audio.Stop();
    }

	/**
     * Lance la lecture.
     *
     */
    public void StartPlaying()
    {
        if (IsPlaying) return;
        audio.time = offset;
        audio.Play();
        IsPlaying = true;
    }

	/**
     * Stop la lecture.
     *
     */
    public void StopPlaying()
    {
        if (!IsPlaying) return;

        audio.Stop();
        IsPlaying = false;
    }
}