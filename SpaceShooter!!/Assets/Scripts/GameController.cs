using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float StartWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    private int score;
    private enum HazardType {asteroid, enemy, powerUp};



    private bool gameOver;
    private bool restart;
     void Start()
    {
       gameOver = false;
       restart = false;
       restartText.text = "";
       gameOverText.text = "";
       score = 0;
       UpdateScore();
       StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {


            Application.LoadLevel(Application.loadedLevel);
            
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {

                int index = Random.Range(0,12);
                switch (index)
                {
                    case (0):
                    case (1):
                    case (2):
                    case (3):
                    case (4):
                    case (5):
                    case (6):
                    case (7):   
                    case (8):
                        hazard = hazards[(int)HazardType.asteroid];
                        break;
                    case (9):
                    case (10):
                        hazard = hazards[(int)HazardType.enemy];
                        break;
                    case (11):
                        hazard = hazards[(int)HazardType.powerUp];
                        break;
                }
                
                

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press R for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
