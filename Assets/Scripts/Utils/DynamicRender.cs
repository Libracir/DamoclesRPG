using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicRender : MonoBehaviour
{

    SpriteRenderer renderer;

    private void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
    }
}