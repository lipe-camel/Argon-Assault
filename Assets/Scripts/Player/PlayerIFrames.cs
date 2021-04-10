using System.Collections;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int numberOfFlashes = 10;
    [SerializeField] float flashDuration = 0.1f;

    //CACHED INTERNAL REFERENCES
    Player player;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    internal IEnumerator ManageIframes()
    {
        int temp = 0;
        player.boxCollider.enabled = false;
        Debug.Log($"{this.name} colliders are enabled? {player.boxCollider.enabled}");
        while (temp < numberOfFlashes)
        {
            player.meshRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            player.meshRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        player.boxCollider.enabled = true;
        Debug.Log($"{this.name} colliders are enabled? {player.boxCollider.enabled}");
    }
}