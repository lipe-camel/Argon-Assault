using System.Collections;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{
    //CONFIG PARAMS

    //CACHED INTERNAL REFERENCES
    Player player;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

}