using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public int moneyAmount = 1;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.coin += moneyAmount;
            GameManager.instance.ShowText("+" + moneyAmount, 15, Color.yellow, transform.position, Vector3.up * 50, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
