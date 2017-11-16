using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static int brickCount;

    void Start()
    {
        brickCount = FindObjectsOfType<Brick>().Length;
    }



    public void LevelLoad(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void ExitGame()
    {
        print("tried to exit");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void CheckBrickCount()
    {
        
        if (brickCount <= 0)
        {
            LoadNextLevel();
        }

    }
}
