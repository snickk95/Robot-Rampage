using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;


void spawnPickup()
    {
        //make a random pick up

        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);

        pickup.transform.position = transform.position;

        pickup.transform.parent = transform;
    }
   
    //20 second delay befor calling it again
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }


    //call spawn pickup
     void Start()
    {
        spawnPickup();   
    }


    //starts a coroutine fro respawn pick up
    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup");
    }
}
