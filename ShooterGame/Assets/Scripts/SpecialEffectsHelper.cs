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

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }
    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffect, position);
        instantiate(fireEffect, position);
    }

 
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}