using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    //CONFIG STATS
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;

    // CACHED REFERENCES
    Player player;    

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

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
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;
        //Debug.Log($"{xThrow}, {yThrow}");
        player.playerMovement.ProcessPlayerMovement(xThrow, yThrow);
    }

    private void ManageFireInput()
    {
        if (fire.ReadValue<float>() > 0.5f)
        {
            player.playerFire.SetLasersActive(true);
        }
        else
        {
            player.playerFire.SetLasersActive(false);
        }
    }
}
