using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    private static Game singleton;

    public GameUI gameUI;

    public GameObject player;

    public int score;
    public int waveCountdown;

    public bool isGameOver;



    [SerializeField]
    robotSpawn[] spawns;

    public int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        //initalize the singlton then calls the spawn robot function
        singleton = this;
        StartCoroutine("increaseScoreEachSec");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("UpdateWaveTimer");
        spawnRobots();
    }

    private IEnumerator UpdateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            waveCountdown--;
            gameUI.setWaveText(waveCountdown);


            if (waveCountdown == 0)
            {
                spawnRobots();
                waveCountdown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.setEnemyText(singleton.enemiesLeft);

        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();

        }
    }

    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.setScoreText(score);
    }

    IEnumerator increaseScoreEachSec()
    {
        yield return new WaitForSeconds(1f);
        score += 1;
        gameUI.setScoreText(score);
    }
        


    private void spawnRobots()
    {
        //goes through each member in the arra y to call spawn robots
        foreach(robotSpawn spawn in spawns)
        {
            spawn.spawnRobot();
            enemiesLeft++;
            gameUI.setEnemyText(enemiesLeft);
            Game.RemoveEnemy();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
