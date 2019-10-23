using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject gameOverPannel;

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


    public void OnGUI()
    {
        if(isGameOver&& Cursor.visible==false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        gameOverPannel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.sceneBattle);
        gameOverPannel.SetActive(true);
    }


    public void quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.sceneMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
