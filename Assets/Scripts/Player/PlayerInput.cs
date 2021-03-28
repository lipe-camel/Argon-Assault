using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    //CONFIG STATS
    [SerializeField] InputAction movement;

    // CACHED REFERENCES
    Player player;    


    public void CustomStart()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    void Update()
    {
        ManageInputs();
    }


    private void ManageInputs()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;
        Debug.Log(xThrow + ", " +  yThrow);
        player.playerMovement.ProcessPlayerMovement(xThrow, yThrow);
    }
}
