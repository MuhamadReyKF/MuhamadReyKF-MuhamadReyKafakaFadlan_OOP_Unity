using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveVelocity = 3 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move()
    {
        float inputX = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ? 1 :
                    Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        float inputY = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ? 1 :
                    Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

        moveDirection = new Vector2(inputX, inputY).normalized;

        Vector2 friction = GetFriction();
        Vector2 targetVelocity = moveDirection * maxSpeed;

        rb.velocity = Vector2.ClampMagnitude(
            rb.velocity + (moveVelocity * moveDirection * Time.fixedDeltaTime) + (friction * Time.fixedDeltaTime),
            maxSpeed.magnitude
        );

        if (rb.velocity.magnitude < stopClamp.magnitude)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public Vector2 GetFriction()
    {
        return rb.velocity.magnitude > 0 ? moveFriction : stopFriction;
    }

    public void MoveBound()
    {
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0;
    }
}

