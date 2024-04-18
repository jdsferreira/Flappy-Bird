using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get game manager Instance
        var gameManager = GameManager.Instance;

        //ignore if game is over
        if(gameManager.IsGameOver()){
            return;
        }
        
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f){
            cooldown = GameManager.Instance.obstacleInterval;

            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];
            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsertY.x, gameManager.obstacleOffsertY.y);

            Vector3 position = new Vector3(x, y, 0);
            Quaternion rotation = prefab.transform.rotation;

            Instantiate(prefab, position, rotation);
        }
    }
}
