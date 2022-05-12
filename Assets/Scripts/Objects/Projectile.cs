using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Collidable
{
    public int damage = 1;
    public float knockback = 2f;
    public float speed = 1f;
    public float duration = 3f;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Decay());
    }

    protected override void OnCollide(Collider2D coll)
    {

        if (coll.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (coll.tag == "Fighter")
        {
            if (coll.name != "player")
            {
                Damage dmg = new Damage
                {
                    damageAmount = damage,
                    origin = transform.position,
                    pushForce = knockback
                };

                coll.SendMessage("ReceiveDamage", dmg);
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        this.transform.position += transform.up * speed * Time.deltaTime;
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
