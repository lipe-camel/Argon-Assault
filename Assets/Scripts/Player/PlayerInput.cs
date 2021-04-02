using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    //CONFIG STATS
    //[SerializeField] InputAction movement;
    //[SerializeField] InputAction fire;

    // CACHED REFERENCES
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
        //float xThrow = movement.ReadValue<Vector2>().x;
        //float yThrow = movement.ReadValue<Vector2>().y;
        float xThrow = Input.GetAxis(HORIZONTAL_AXIS);
        float yThrow = Input.GetAxis(VERTICAL_AXIS);
        //Debug.Log($"{xThrow}, {yThrow}");
        player.playerMovement.ProcessPlayerMovement(xThrow, yThrow);
    }

    private void ManageFireInput()
    {
        //if (fire.ReadValue<float>() > 0.5f)
        if(Input.GetButton(FIRE_BUTTON))
        {
            player.playerFire.SetLasersActive(true);
        }
        else
        {
            player.playerFire.SetLasersActive(false);
        }
    }
}
