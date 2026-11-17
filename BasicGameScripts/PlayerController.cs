using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float minX = -8f;
    public float maxX = 8f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 position = transform.position;
        position.x += move * speed * Time.deltaTime;

        if (position.x < minX)
            position.x = minX;

        if (position.x > maxX)
            position.x = maxX;

        transform.position = position;
    }
}