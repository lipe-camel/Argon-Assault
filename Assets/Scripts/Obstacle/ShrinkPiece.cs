using UnityEngine;

public class ShrinkPiece : MonoBehaviour
{
    [SerializeField] float growRate = -3f;

    private void Update()
    {
        if (transform.localScale.x > 0.1)
        {
            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f) * growRate * Time.deltaTime;
        }
    }
}