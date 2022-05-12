using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1f;

    protected RaycastHit2D hit;

    protected override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input, float speed)
    {
        moveDelta = new Vector3(input.x * (xSpeed * speed), input.y * (ySpeed * speed), 0);

        moveDelta += pushDirection;

        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        transform.Translate(moveDelta * Time.deltaTime);
    }
}

