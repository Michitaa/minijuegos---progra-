using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float climbSpeed = 3f;

    private Rigidbody rb;
    private bool isClimbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
   
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (!isClimbing)
        {
         

            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

        }
        else
        {
          
            float verticalInput = 0f;

            if (Input.GetKey(KeyCode.E)) verticalInput = 1f;     // Go up
            else if (Input.GetKey(KeyCode.Q)) verticalInput = -1f; // Go down

            rb.linearVelocity = new Vector3(0f, verticalInput * climbSpeed, 0f);

            rb.linearVelocity = new Vector3(0f, verticalInput * climbSpeed, 0f);

        }
    }

    public void SetClimbing(bool state)
    {
        isClimbing = state;
        rb.useGravity = !state; 
    }
}