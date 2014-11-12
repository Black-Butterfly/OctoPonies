using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour
{
	/// <summary>
	/// Singleton
	/// </summary>

	public static SpecialEffectsHelper Instance;
	
	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;
	public ParticleSystem collectibleEffect;

    private Transform layer;
	private float runCpt;
	private float cdRun = 0.5f;

	void Awake()
	{
		// Register the singleton
		if (Instance == null)
		{
			//Debug.LogError("Multiple instances of SpecialEffectsHelper!");
			runCpt = 0f;
            Instance = this;
            layer = GameObject.Find("Layer2").transform;
		}
		
		
	}

	void Update ()
	{
		if (runCpt > 0) runCpt -= Time.deltaTime;
	}

	public void Explosion(Vector3 position)
	{
		var c1 = instantiate(smokeEffect, position);
        c1.transform.parent = layer;
        c1.renderer.sortingLayerName = "Layer 2";
		var c2 = instantiate(fireEffect, position);
        c2.transform.parent = layer;
        c2.renderer.sortingLayerName = "Layer 2";
	}

	public void Running(Vector3 position)
	{
		if (runCpt <= 0) {
			var c = instantiate (smokeEffect, position);
            c.transform.parent = layer;
            c.renderer.sortingLayerName = "Layer 2";
			runCpt = cdRun;
		}
	}

	public void Collect(Vector3 position)
	{
		var c = instantiate(fireEffect, position);
        c.transform.parent = layer;
        c.renderer.sortingLayerName = "Layer 2";
	}
	
	/// <summary>
	/// Instantiate a Particle system from prefab
	/// </summary>
	/// <param name="prefab"></param>
	/// <returns></returns>
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;
		
		// Make sure it will be destroyed
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}