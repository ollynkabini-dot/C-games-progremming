using UnityEngine;

public class DestroyBelow : MonoBehaviour
{
    public float bottomLimit = -6f;

    void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}