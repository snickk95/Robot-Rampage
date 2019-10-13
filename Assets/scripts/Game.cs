using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game singleton;

    [SerializeField]
    robotSpawn[] spawns;

    public int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        //initalize the singlton then calls the spawn robot function
        singleton = this;
        spawnRobots();
    }
    

    private void spawnRobots()
    {
        //goes through each member in the arra y to call spawn robots
        foreach(robotSpawn spawn in spawns)
        {
            spawn.spawnRobot();
            enemiesLeft++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
