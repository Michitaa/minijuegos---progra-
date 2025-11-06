using UnityEngine;
using System;

public class PlayerController : MovableEntity, IDamageable
{
    private bool canJump = true;

    public Action OnJumped;

    protected override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * MovementSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move(); 

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        if (IsGrounded != null && IsGrounded.Invoke())
        {
            canJump = true;
        }
    }

    private void Jump()
    {
        OnJumped?.Invoke();
        canJump = false;
    }

    public void TakeDamage()
    {
        GameManager.Instance.LoseLife();

        Invoke("ResetPosition", 1f);
    }

    private void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
}