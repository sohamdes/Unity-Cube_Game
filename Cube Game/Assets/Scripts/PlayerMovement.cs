using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public GameObject deathParticles;
    private float maxSpeed = 5;

    private Vector3 input;
    private Vector3 spawn;
    
	// Use this for initialization
	void Start () {
        spawn = transform.position;

	}
	

	void Update () {
        //       input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //       if (GetComponent<Rigidbody>().velocity < maxSpeed){

        //           GetComponent<Rigidbody>().AddForce(input * moveSpeed);


        //       }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal,0, vertical);
        transform.position += movement * Time.deltaTime * maxSpeed;

        if(transform.position.y < -2 ){
            Die();
        }

    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            Die();
        }

        if(collision.gameObject.CompareTag("Goal"))
        {
            GameManager.CompleteLevel();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.transform.tag == "Goal"){
    //        GameManager.CompleteLevel();
    //    }
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Goal"))
    //    {
    //        GameManager.CompleteLevel();
    //    }
    //}

    void Die(){

        Instantiate(deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
        transform.position = spawn;
    }
}
