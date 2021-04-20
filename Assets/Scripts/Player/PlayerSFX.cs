using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] AudioClip laserSound;


    internal void CustomStart()
    {
    }

    internal void PlayLaserSound()
    {
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position);
    }
}