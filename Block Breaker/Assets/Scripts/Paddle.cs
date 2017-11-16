using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private Transform paddleTrans;

    public float paddleHeight = -9;

    void Start() {
        paddleTrans = gameObject.GetComponent<Transform> ();
    }

	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = paddleHeight;
        mousePos.z = 0;
        paddleTrans.position = mousePos;
   
    }
}
