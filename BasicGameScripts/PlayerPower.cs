using System.Collections;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public bool hasPowerup = false;
    public float powerupDuration = 5f;
    public GameObject powerupIndicator;

    private PlayerController playerController;
    private float originalSpeed;
    private Coroutine powerupRoutine;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        if (playerController != null)
            originalSpeed = playerController.speed;

        if (powerupIndicator != null)
            powerupIndicator.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            Destroy(other.gameObject);

            if (powerupRoutine != null)
                StopCoroutine(powerupRoutine);

            powerupRoutine = StartCoroutine(PowerupCountdown());
        }
    }

    IEnumerator PowerupCountdown()
    {
        hasPowerup = true;

        if (playerController != null)
            playerController.speed = originalSpeed * 4f;

        if (powerupIndicator != null)
            powerupIndicator.SetActive(true);

        yield return new WaitForSeconds(powerupDuration);

        if (playerController != null)
            playerController.speed = originalSpeed;

        if (powerupIndicator != null)
            powerupIndicator.SetActive(false);

        hasPowerup = false;
        powerupRoutine = null;
    }
}