using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collect"))
        {
            if (gameManager != null)
                gameManager.AddScore(1);

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Hazzard"))
        {
            if (gameManager != null)
                gameManager.LoseLife();

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Orb"))
        {
            Destroy(other.gameObject);
        }

        // PlayerPower handles PowerUp objects separately.
    }
}