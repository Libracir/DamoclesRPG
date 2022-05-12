using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Transform target;
    private void Awake()
    {
        this.transform.parent = null;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.position = target.position;
        transform.rotation = target.rotation;
        transform.position += new Vector3(0f, -0.3f, 0f);
    }
}
