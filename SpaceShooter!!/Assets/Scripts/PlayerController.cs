using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//by having this class i can seperate and minimize this information in unity so its easier to look at
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public float fireRate;
    private float nextFire;
    public Boundary boundary;
    private Rigidbody rb;
    public GameObject shot;
    public Transform shotSpawn;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if((Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            //apply power up
            fireRate -= 0.05f;
            Destroy(other.gameObject);
        }
        else
        {
            //do nothing
            return;
        }
    }
}
