using System.Collections;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int numberOfFlashes = 4;
    [SerializeField] float flashDuration = 0.1f;

    //CACHED INTERNAL REFERENCES
    Player player;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    internal void ManageIframes()
    {
        int temp = 0;
        player.boxCollider.enabled = false;
        Debug.Log($"{this.name} colliders are enabled? {player.boxCollider.enabled}");
        while(temp < numberOfFlashes)
        {
            StartCoroutine(ToggleVisibility(false));        
            StartCoroutine(ToggleVisibility(true));
            temp++;
        }
        player.boxCollider.enabled = true;
        Debug.Log($"{this.name} colliders are enabled? {player.boxCollider.enabled}");
    }

    private IEnumerator ToggleVisibility(bool isMeshEnabled)
    {
        player.meshRenderer.enabled = isMeshEnabled;
        Debug.Log($"Mesh renderes are enabled? {isMeshEnabled}");

        yield return new WaitForSeconds(flashDuration);
    }
}