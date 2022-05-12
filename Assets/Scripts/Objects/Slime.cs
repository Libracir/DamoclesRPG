using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public Animator anim;
    public bool die = false;
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }
    protected override void Death()
    {
        GameManager.instance.experience += xpValue;
        MovementBlock = true;
        DamageBlock = true;
        boxCollider.enabled = false;
        GetComponentInChildren<EnemyHitbox>().enabled = false;
        anim.SetTrigger("Death");
    }
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
