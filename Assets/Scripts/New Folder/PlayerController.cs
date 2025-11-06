using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MovableEntity, IDamageable
{
    private bool canJump = true;
    private bool hasHammer = false;
    public Action OnJumped;
    public Action<bool> OnHammerStateChanged;
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
    public void ActivateHammer(float duration)
    {
        hasHammer = true;
        OnHammerStateChanged?.Invoke(true);
        // CÓDIGO CORREGIDO:
        StartCoroutine(DeactivateHammerRoutine(duration));
    }

    private void DeactivateHammer()
    {
        hasHammer = false;
        OnHammerStateChanged?.Invoke(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasHammer)
        {
            IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();

            if (damageableObject != null)
            {
                damageableObject.TakeDamage();
            }
        }
    }
    private IEnumerator DeactivateHammerRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        Action deactivateAction = () => { DeactivateHammer(); };
        deactivateAction.Invoke();
    }




}