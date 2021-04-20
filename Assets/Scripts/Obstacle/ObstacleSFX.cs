using UnityEngine;

internal class ObstacleSFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] AudioClip[] damageSounds, deathSounds;
    [SerializeField] float audioVolume = 0.2f;

    
    internal void CustomStart()
    {
    }

    internal void PlayDamageSFX()
    {
        AudioSource.PlayClipAtPoint(GetRandomAudio(damageSounds), Camera.main.transform.position, audioVolume);
    }

    internal void PlayDeathSFX()
    {
        AudioSource.PlayClipAtPoint(GetRandomAudio(deathSounds), Camera.main.transform.position, audioVolume);
    }

    private AudioClip GetRandomAudio(AudioClip[] audioClips)
    {
        int randomAudio = Random.Range(0, audioClips.Length);
        return audioClips[randomAudio];
    }
}