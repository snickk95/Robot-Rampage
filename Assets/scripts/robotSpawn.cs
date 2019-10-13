using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] robots;


    private int timesSpawned;
    private int healthBonus = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    //creates a robot sets it's health and psoition
    public void spawnRobot()
    {
        timesSpawned++;
        healthBonus += 1 * timesSpawned;

        GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);

        robot.transform.position = transform.position;
        robot.GetComponent<Robot>().health += healthBonus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
