using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30;
    public int damage = 10;
    //start the corourtine death timer
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    //move the missle
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //set it up so the miossle destroys if it doesnt hit the player
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
