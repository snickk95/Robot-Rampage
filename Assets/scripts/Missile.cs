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

    //checks if the missle hit the player if it does it will pass the damage into the take damage function in the player script
     void OnCollisionEnter(Collision collider)
    {
      if(collider.gameObject.GetComponent<Player>() !=null && collider.gameObject.tag=="Player" )
        {
            collider.gameObject.GetComponent<Player>().takeDamage(damage);
        }

        Destroy(gameObject);
        
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
