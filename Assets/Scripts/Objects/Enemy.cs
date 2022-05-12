using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLength = 4;
    public float chaseLength = 10;
    public float speed = 2;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    public bool MovementBlock;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (!MovementBlock)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
            {
                if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                {
                    chasing = true;
                }

                if (chasing)
                {
                    if (!collidingWithPlayer)
                    {
                        UpdateMotor((playerTransform.position - transform.position).normalized, speed);
                    }
                }
                else
                {
                    UpdateMotor(startingPosition - transform.position, speed);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position, speed);
                chasing = false;
            }

            collidingWithPlayer = false;
            boxCollider.OverlapCollider(filter, hits);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] == null)
                    continue;

                if (hits[i].tag == "Fighter" && hits[i].name == "player")
                {
                    collidingWithPlayer = true;
                }

                hits[i] = null;
            }
        }
    }

    protected override void Death()
    {
        GameManager.instance.experience += xpValue;
        Destroy(gameObject);
    }
}
