using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody thisRigidBody;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;

    void Start()
    {
        
        thisRigidBody = GetComponent<Rigidbody>();
        //temporaizer 
        //force up to player
        
    }

    // Update is called once per frame
    void Update()
    {
                
        //Get game manager Instance
        var gameManager = GameManager.Instance;

        jumpCooldown -= Time.deltaTime;
        bool isGameActive = gameManager.IsGameActive();
        bool canJump = jumpCooldown <=0 && isGameActive;
        // space bar?
        bool jumpInput = Input.GetKey(KeyCode.Space);
        if(canJump){
            if(jumpInput){
            Jump();
            }
        }
       
       //Toggle Gravity
       thisRigidBody.useGravity = isGameActive;
        
    }

    void OnCollisionEnter(Collision other){
        
        OnCustomCollisionEnter(other.gameObject);
        

    }

    void OnTriggerEnter(Collider other){
        
        OnCustomCollisionEnter(other.gameObject);

      }

    private void OnCustomCollisionEnter(GameObject other){
        bool isSensor = other.CompareTag("Sensor");
        
        if(isSensor){
            GameManager.Instance.scoreText.gameObject.SetActive(true);
            GameManager.Instance.score++;
            GameManager.Instance.scoreText.text = Convert.ToString(GameManager.Instance.score);
            Debug.Log("Score: " + GameManager.Instance.score);

        } else{
            //Game Over
            GameManager.Instance.EndGame();


        }

    }

    private void Jump(){
        jumpCooldown = jumpInterval;

        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

    }
}
