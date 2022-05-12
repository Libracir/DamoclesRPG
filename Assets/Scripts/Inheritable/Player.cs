using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    protected float speed = 4;

    protected override void ReceiveDamage(Damage dmg)
    {
        base.ReceiveDamage(dmg);
        GameManager.instance.ScreenShake(0.25f, 0.06f);
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0), speed);
    }
}
