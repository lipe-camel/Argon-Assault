using System.Collections;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] AudioClip laserSound;
    [SerializeField] float timeBetweenShots = 0.1f;


    //CACHED CLASSES REFERENCES
    Player player;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    internal IEnumerator PlayLaserSound()
    {
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position);
        yield return new WaitForSeconds(timeBetweenShots);
    }
}