using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    //CONFIG STATS
    //[SerializeField] InputAction movement;
    //[SerializeField] InputAction fire;

    // CACHED INTERNAL REFERENCES
    Player player;

    //CACHED STRING REFERENCES
    const string HORIZONTAL_AXIS = "Horizontal";
    const string VERTICAL_AXIS = "Vertical";
    const string FIRE_BUTTON = "Fire";


    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    //private void OnEnable()
    //{
    //    movement.Enable();
    //    fire.Enable();
    //}

    //private void OnDisable()
    //{
    //    movement.Disable();
    //    fire.Disable();
    //}

    private void Update()
    {
        ManageInputs();
    }

    //INPUT MANAGER
    private void ManageInputs()
    {
        if (player.isAlive)
        {
            ManageMovementInput();
            ManageFireInput();
        }
    }

    private void ManageMovementInput()
    {
        if(!player.canMove) { return; }

        float xThrow = Input.GetAxis(HORIZONTAL_AXIS);
        float yThrow = Input.GetAxis(VERTICAL_AXIS);
        player.playerMovement.ProcessPlayerMovement(xThrow, yThrow);
    }

    private void ManageFireInput()
    {
        if(!player.canFire) { return; }

        if(Input.GetButtonDown(FIRE_BUTTON))
        {
            player.playerSFX.PlayLaserSFX();
            player.playerFire.SetLasersActive(true);
        }
        if(Input.GetButtonUp(FIRE_BUTTON))
        {
            player.playerFire.SetLasersActive(false);
        }
    }
}
