using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barrel : MovableEntity, IDamageable
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        // Simple 3D rolling motion
        rb.angularVelocity = Vector3.forward * MovementSpeed;
        rb.linearVelocity = Vector3.right * -MovementSpeed; // Move to the left
    }

    private void FixedUpdate()
    {
        Move();
    }

    // This is the 3D collision check
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the Player
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            // If it hits the player, invoke the damage logic on the player
            player.TakeDamage();

            // Destroy the barrel after the hit
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        // Logic for when the barrel is hit by the hammer
        // We could implement an event here later, but for simplicity, just destroy it.
        Destroy(gameObject);

        // Reward the player
        GameManager.Instance.IncreaseScore(100);
    }
}