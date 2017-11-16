using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject paddle;

    private bool playing = false;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigid;
	void Start () {
       paddleToBallVector = this.transform.position - paddle.transform.position;
        rigid = this.GetComponent<Rigidbody2D>();
        Debug.Log(rigid);
	}
	
	void Update () {
        if (!playing) {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                rigid.velocity = new Vector2(10, 20);
                playing = true;
            }
        }


        

    }
}
