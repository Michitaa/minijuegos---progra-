using UnityEngine;
using System;

public abstract class MovableEntity : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    protected float MovementSpeed { get { return movementSpeed; } }

    protected abstract void Move();

    protected Func<bool> IsGrounded;
}