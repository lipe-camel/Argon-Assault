using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    //
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float yValue, xValue;

    // CACHED REFERENCES
    Player player;

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }


    public void Move(float xFactor, float yFactor)
    {
        float deltaX = xFactor * Time.deltaTime * movementSpeed;
        float deltaY = yFactor * Time.deltaTime * movementSpeed;

        var newXPos = Mathf.Clamp(player.playerModel.transform.position.x + deltaX, -xValue, xValue);
        var newYPos = Mathf.Clamp(player.playerModel.transform.position.y + deltaY, -yValue, yValue);

        player.playerModel.transform.position = new Vector3(player.transform.position.x + newXPos, player.transform.position.y + newYPos);
    }
}
