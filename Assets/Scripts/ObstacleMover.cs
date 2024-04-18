using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         //Get game manager Instance
        var gameManager = GameManager.Instance;

        //ignore if game is over
        if(gameManager.IsGameOver()){
            return;
        }

        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        //Destroy Object
        if(transform.position.x <= -gameManager.obstacleOffsetX){
            Destroy(gameObject);
        }
    }
}
