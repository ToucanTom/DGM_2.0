using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int hp;
    public Sprite[] brickStates;
    // Use this for initialization
    private LevelManager levelManager;

    // Update is called once per frame
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
        
        if(hp<= 0)
        {
            Destroy(this.gameObject);
            LevelManager.brickCount--;
            print(LevelManager.brickCount);
            levelManager.CheckBrickCount();
        }
        else {
            GetComponent<SpriteRenderer>().sprite = brickStates[hp - 1];
        }
       
    }
}
