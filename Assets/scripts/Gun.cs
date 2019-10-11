﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    protected float lastFireTime;

    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;

    // Start is called before the first frame update
    void Start()
    {
        lastFireTime = Time.time - 10;
    }


    protected virtual void Update()
    {


    }
    protected void Fire()
    {
        //plays a audio clip depending if you fire a bullet or if you dont have bullets
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.usedAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
            
        }
        GetComponentInChildren<Animator>().Play("fire");
    }
       
    
}
