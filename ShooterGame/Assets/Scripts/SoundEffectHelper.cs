using UnityEngine;
using System.Collections;

public class SoundEffectHelper : MonoBehaviour
{
    public static SoundEffectHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
