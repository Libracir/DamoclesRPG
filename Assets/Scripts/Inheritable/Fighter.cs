using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    public bool DamageBlock;

    protected float immuneTime = 0.25f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (!DamageBlock)
        {
            if (Time.time - lastImmune > immuneTime)
            {
                Flash();
                lastImmune = Time.time;
                hitpoint -= dmg.damageAmount;
                pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

                GameManager.instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.up * 50, 0.5f);

                if (hitpoint <= 0)
                {
                    hitpoint = 0;
                    Death();
                }
            }
        }
    }

    private void Flash()
    {
        spriteRenderer.color = Color.red;
        StartCoroutine(FlashDisable());
    }

    IEnumerator FlashDisable()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    protected virtual void Death()
    {
    }
}
