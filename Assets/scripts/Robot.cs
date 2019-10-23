using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private AudioClip fireSound;

    [SerializeField]
    private AudioClip weakHitSound;


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
        //set the agent nav mash and player location on start up
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //same as the player take damage but also calls a death animation for the robot
    public void takeDamage(int amount)
    {
        if (isdead)
        {
            return;
        }

        health -= amount;
        if (health<=0)
        {
            isdead = true;
            robot.Play("die");
            StartCoroutine("DestroyRobot");

            //plays death sound for robot
            GetComponent<AudioSource>().PlayOneShot(deathSound);

        }
        else
        {
            //plays a hit sound
            GetComponent<AudioSource>().PlayOneShot(weakHitSound);
        }
       
    }

    //adds a delay to the destroy of the robot so the animation can play
    IEnumerator DestroyRobot()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        
        Game.RemoveEnemy();
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

        robot.Play("missile");
        //play audio for firing
        GetComponent<AudioSource>().PlayOneShot(fireSound);
    }
}
