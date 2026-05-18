using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Set in Inspector

    private Rigidbody2D rb;
    private Vector2 moveDir;   // Current movement direction
    private Knockback knockback;

    private void Awake()
    {
        // Grab components on startup
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move enemy each physics step based on direction and speed
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        // Update movement direction when given a new target
        moveDir = targetPosition;
    }
}