using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    // CACHED REFERENCES
    Player player;

    //STRING REFERENCES
    const string HORIZONTAL_AXIS = "Horizontal";
    const string VERTICAL_AXIS = "Vertical";

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        ManageInputs();
    }

    private void ManageInputs()
    {
        float xFactor = Input.GetAxis(HORIZONTAL_AXIS);
        float yFactor = Input.GetAxis(VERTICAL_AXIS);

        player.playerMovement.Move(xFactor, yFactor);
    }
}
