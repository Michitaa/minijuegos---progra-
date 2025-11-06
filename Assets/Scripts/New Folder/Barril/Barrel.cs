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
        rb.angularVelocity = Vector3.forward * MovementSpeed;
        rb.linearVelocity = Vector3.right * -MovementSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
   
            player.TakeDamage();
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
        GameManager.Instance.IncreaseScore(100);
    }
}