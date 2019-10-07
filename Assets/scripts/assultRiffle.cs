using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assultRiffle : Gun
{
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();

        if(Input.GetMouseButton(0) &&(Time.time - lastFireTime)>fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
