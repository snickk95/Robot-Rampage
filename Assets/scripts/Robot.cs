using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;

    [SerializeField]
    private string robotType;

    public int health;
    public int range;
    public float fireRate;

    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;


    private Transform player;
    private float timeLastFired;

    private bool isdead;

    public Animator robot;
    // Start is called before the first frame update
    void Start()
    {
        // the robots are set to true to begin with so we need to set that value 
        isdead = false;
        //set the agent nav mash and player location oon start up
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the robots are dead
        if (isdead)
        {
            return;
        }
        //mnake the robot face the player
        transform.LookAt(player);

        //makes destination to go the player character
        agent.SetDestination(player.position);

        //checks to see if the player is in range and if the robot is able to fire yet
        if (Vector3.Distance(transform.position,player.position)<range&& Time.time-timeLastFired>fireRate)
        {
            //resets the time from last fired then calls the fire function
            timeLastFired = Time.time;
            fire();
        }
    }
    //creates a new missile prefab and puts in on the robots cannon
  private void fire ()
    {
        GameObject missile = Instantiate(missileprefab);

        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;

        robot.Play("fire");
    }
}
