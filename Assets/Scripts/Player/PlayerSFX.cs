using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] AudioSource laserSound;
    [SerializeField] AudioClip[] damageSounds, deathSounds;
    [SerializeField] float 
        damageVolume = 0.2f,
        deathVolume = 0.5f;


    internal void CustomStart()
    {
        //laserSound = GetComponentInChildren<AudioSource>();
        //Debug.Log(laserSound.gameObject.name);
    }

    internal void PlayLaserSFX()
    {
        laserSound.Play();
    }
    internal void PlayDamageSFX()
    {
        AudioSource.PlayClipAtPoint(GetRandomAudio(damageSounds), Camera.main.transform.position, damageVolume);
    }

    internal void PlayDeathSFX()
    {
        AudioSource.PlayClipAtPoint(GetRandomAudio(deathSounds), Camera.main.transform.position, deathVolume);
    }


    private AudioClip GetRandomAudio(AudioClip[] audioClips)
    {
        int randomAudio = Random.Range(0, audioClips.Length);
        return audioClips[randomAudio];
    }
}