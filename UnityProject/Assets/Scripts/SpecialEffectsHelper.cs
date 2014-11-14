/**
 * @file    SpecialEffectsHelper.cs
 *
 * @author  Octoponies
 *
 * @date    14/11/2014
 *
 * @version 0.1
 *
 * @brief   Gestion de particule.
 *
 */

using UnityEngine;

/**
 * @brief La classe SpecialEffectsHelper gère les effets de particule.
 *
 */
public class SpecialEffectsHelper : MonoBehaviour
{
	/** @brief SpecialEffectsHelper instance de particule */
	public static SpecialEffectsHelper Instance;

	/** @brief smokeEffect particule de fumé */
	public ParticleSystem smokeEffect;
	/** @brief fireEffect particule de feu */
	public ParticleSystem fireEffect;
	/** @brief collectibleEffect particule de collectible */
	public ParticleSystem collectibleEffect;

	/** @brief layer contient le layer d'affichage */
    private Transform layer;
	/** @brief runCpt temps restant avant nouvelle particule */
	private float runCpt;
	/** @brief runCpt temps avant nouvelle particule */
	private float cdRun = 0.5f;

	/**
     * S'execute lors de la création du script.
     * Initialisation
     *
     */
	void Awake()
	{
		if (Instance == null)
		{
			runCpt = 0f;
            Instance = this;
            layer = GameObject.Find("Layer2").transform;
		}
	}

	/**
	 * Appellé à chaque frame
     * Met à jour le delai
     *
     */
	void Update ()
	{
		if (runCpt > 0) runCpt -= Time.deltaTime;
	}

	/**
     * Crée une explosion
     *
     */
	public void Explosion(Vector3 position)
	{
		var c1 = instantiate(smokeEffect, position);
        c1.transform.parent = layer;
        c1.renderer.sortingLayerName = "Layer 2";
		var c2 = instantiate(fireEffect, position);
        c2.transform.parent = layer;
        c2.renderer.sortingLayerName = "Layer 2";
	}

	/**
     * Particule lorsque le joueur cours
     *
     */
	public void Running(Vector3 position)
	{
		if (runCpt <= 0) {
			var c = instantiate (smokeEffect, position);
            c.transform.parent = layer;
            c.renderer.sortingLayerName = "Layer 2";
			runCpt = cdRun;
		}
	}

	/**
     * Particule pour les collectibles
     *
     */
	public void Collect(Vector3 position)
	{
		var c = instantiate(fireEffect, position);
        c.transform.parent = layer;
        c.renderer.sortingLayerName = "Layer 2";
	}
	
	/**
     * Crée les particules et les détruits en fin de vie
     *
     */
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;

		Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
		
		return newParticleSystem;
	}
}