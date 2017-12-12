using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for laser blasts
public class Mover : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
	void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }
}
