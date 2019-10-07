using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : Gun
{
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
        //automatic firing
        if(Input.GetMouseButtonDown(0) &&(Time.time - lastFireTime)>fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
