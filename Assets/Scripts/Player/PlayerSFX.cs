using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] AudioSource laserSound;
    [SerializeField] float laserVolume;

    //CACHED COMPONENT REFERENCES
    


    internal void CustomStart()
    {
        //laserSound = GetComponentInChildren<AudioSource>();
        Debug.Log(laserSound.gameObject.name);
    }

    internal void PlayLaserSound()
    {
        laserSound.Play();
    }
}