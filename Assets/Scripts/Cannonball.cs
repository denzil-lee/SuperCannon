using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : DefaultBullet
{
    // Start is called before the first frame update
    protected override void OnEnable()
    {
        base.OnEnable();
        rb.gravityScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
