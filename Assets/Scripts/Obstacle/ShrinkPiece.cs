using UnityEngine;

public class ShrinkPiece : MonoBehaviour
{
    [SerializeField] float growRate = -25f;

    private void Update()
    {
        if (transform.localScale.x > 0.1)
        {
            transform.localScale +=
                new Vector3(0.1F, 0.1f, 0.1f) *
                growRate *
                transform.localScale.x *
                Time.deltaTime;
            growRate *= 1.001f;
        }
    }
}