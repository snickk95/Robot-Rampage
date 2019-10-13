﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.GetComponent<Player>()!= null && collider.gameObject.tag =="Player")
        {
            collider.gameObject.GetComponent<Player>().PickUpItem(type);

            GetComponent<pickUpSpawn>().PickupWasPickedUp();

            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
