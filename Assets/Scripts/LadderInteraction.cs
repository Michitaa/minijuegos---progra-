using UnityEngine;

public class LadderInteraction : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool playerInZone = false;
    private Rigidbody playerRb;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            playerRb = other.GetComponent<Rigidbody>();
            playerRb.useGravity = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            playerRb.useGravity = true; 
            playerRb = null;
        }
    }

    void Update()
    {
        if (playerInZone && playerRb != null)
        {
            float verticalInput = 0f;

            if (Input.GetKey(KeyCode.E))
                verticalInput = 1f;
            else if (Input.GetKey(KeyCode.Q))
                verticalInput = -1f;

            playerRb.linearVelocity = new Vector3(0f, verticalInput * climbSpeed, 0f);
        }
    }
}